package coinapp.example.coinapp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.coinapp.R;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;
import org.w3c.dom.Text;

import java.math.RoundingMode;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import coinapp.example.coinapp.models.CoinData;

public class converter extends AppCompatActivity {

    List<CoinData> coinDataList = new ArrayList<>();
    ArrayList<String> coinDataStringList = new ArrayList<>();

    Double HowMany, HowMuch, tempPrice;
    String secondHowMuch = null, secondHowMany = null;
    Double secondHowMuchVolume = null, secondHowManyVolume = null;

    TextView currenyText, unitText, returnText;
    EditText textbox1, textbox2;
    Button button;

    Boolean mode = true;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_converter);

        currenyText = (TextView) findViewById(R.id.currencyText);
        unitText = (TextView) findViewById(R.id.unitText);
        returnText = (TextView) findViewById(R.id.returnText);
        textbox1 = (EditText) findViewById(R.id.textBox1);
        textbox2 = (EditText) findViewById(R.id.textBox2);
        button = (Button) findViewById(R.id.calculator);

        getData();
    }

    String prepareString(String text) {
        text = text.trim();
        if (text.contains(","))
            text = text.replace(",", ".");
        return text;
    }

    public void calc(View view) {
        try {
            DecimalFormat df = new DecimalFormat("#.######");
            df.setRoundingMode(RoundingMode.FLOOR);

            if (mode) {
                HowMany = secondHowMany == prepareString(textbox1.getText().toString()) ? secondHowManyVolume : Double.parseDouble(prepareString(textbox1.getText().toString()));
                HowMuch = HowMany * tempPrice;

                secondHowMuch = prepareString(df.format(HowMuch));
                secondHowMuchVolume = HowMuch;

                String result = String.format("%s %s", secondHowMuch, secondHowMuchVolume);
                Toast.makeText(this, result, Toast.LENGTH_LONG).show();

                textbox2.setText(secondHowMuch);
            } else {
                HowMuch = secondHowMuch == prepareString(textbox2.getText().toString()) ? secondHowMuchVolume : Double.parseDouble(prepareString(textbox2.getText().toString()));
                HowMany = HowMuch / tempPrice;

                secondHowMany = prepareString(df.format(HowMany));
                secondHowManyVolume = HowMany;
                textbox1.setText(secondHowMany);
            }
        } catch (Exception e) {
            Log.e("App", "Hataya düştü.");
        }
    }

    public void change(View v) {
        mode = mode ? false : true;

        if (mode) {
            // ON
            textbox2.setEnabled(!mode);
            textbox1.setTextColor(Color.rgb(255, 255, 255));
            textbox1.setHintTextColor(Color.rgb(255, 255, 255));
            unitText.setTextColor(Color.rgb(255, 255, 255));

            // OFF
            textbox1.setEnabled(mode);
            textbox2.setTextColor(Color.rgb(16, 112, 224));
            textbox2.setHintTextColor(Color.rgb(16, 112, 224));
            returnText.setTextColor(Color.rgb(16, 112, 224));

        } else {

            // ON
            textbox2.setEnabled(!mode);
            textbox2.setTextColor(Color.rgb(255, 255, 255));
            textbox2.setHintTextColor(Color.rgb(255, 255, 255));
            returnText.setTextColor(Color.rgb(255, 255, 255));

            // OFF
            textbox1.setEnabled(mode);
            textbox1.setTextColor(Color.rgb(16, 112, 224));
            textbox1.setHintTextColor(Color.rgb(16, 112, 224));
            unitText.setTextColor(Color.rgb(16, 112, 224));
        }


    }

    public void checkCurrency(String name, List<CoinData> datas) {
        for (CoinData data : datas) {
            if (name == data.coinName) {
                tempPrice = data.coinPrice;
                String tag = "1 " + data.coinName + " = $" + tempPrice;
                currenyText.setText(tag);
                break;
            }

        }
    }

    void convertDataToString(List<CoinData> datas) {
        Spinner spinner = (Spinner) findViewById(R.id.currenyChooser);

        for (CoinData data : datas) {
            coinDataStringList.add(data.coinName);
        }

        ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, coinDataStringList);
        arrayAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinner.setAdapter(arrayAdapter);
        spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                String chosenItem = parent.getItemAtPosition(position).toString();
                checkCurrency(chosenItem, coinDataList);
                calc(button);
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
            }
        });
    }

    void getData() {
        String url = "https://api.coinstats.app/public/v1/coins?skip=0&limit=100&currency=USD";

        final StringRequest request = new StringRequest(url, new Response.Listener<String>() {
            @Override
            public void onResponse(String string) {
                parseJsonData(string);
                convertDataToString(coinDataList);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError volleyError) {
                Toast.makeText(getApplicationContext(), "Some error occurred!!", Toast.LENGTH_SHORT).show();
            }
        });

        RequestQueue rQueue = Volley.newRequestQueue(this);
        rQueue.add(request);
    }

    void parseJsonData(String jsonString) {
        try {
            String tempCoin_name, tempCoin_IconUri;
            Double tempCoin_price, tempCoin_change1d;

            JSONObject objects = new JSONObject(jsonString);
            JSONArray coinsArray = objects.getJSONArray("coins");

            for (int i = 0; i < coinsArray.length(); ++i) {
                JSONObject tempObject = new JSONObject(coinsArray.getString(i));
                tempCoin_name = tempObject.getString("name");
                tempCoin_IconUri = tempObject.getString("icon");

                tempCoin_price = tempObject.getDouble("price");
                String stringedTempCoin_price = tempCoin_price.toString();
                Double resultCoin_price = stringedTempCoin_price.length() > 7 ? null : tempCoin_price;

                if (stringedTempCoin_price.length() > 7) {
                    int commaPosition = stringedTempCoin_price.indexOf(".");
                    String stringedCuttedPrice = stringedTempCoin_price.substring(0, commaPosition + 5);
                    resultCoin_price = Double.parseDouble(stringedCuttedPrice);
                }

                tempCoin_change1d = tempObject.getDouble("priceChange1d");

                CoinData tempCoinData = new CoinData(tempCoin_name, tempCoin_IconUri, resultCoin_price, tempCoin_change1d);
                coinDataList.add(tempCoinData);
            }
        } catch (JSONException e) {
            Log.e("Error", "A error detected while parsing JSON data. Line 195");
        }
    }

    public void gotoPage(View view) {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }
}