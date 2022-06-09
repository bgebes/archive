package coinapp.example.coinapp;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.content.ContextCompat;

import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Color;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.Bundle;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.RelativeLayout;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.coinapp.R;
import com.squareup.picasso.Picasso;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import coinapp.example.coinapp.models.CoinData;

import java.io.BufferedInputStream;
import java.io.InputStream;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {
    List<CoinData> coinDataList = new ArrayList<>();
    int downColor = Color.rgb(255, 9, 9);
    int upColor = Color.rgb(3, 197, 45);

    TableLayout tableLayout;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        tableLayout = (TableLayout) findViewById(R.id.coinTable);

        getData();
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
            Log.e("Error", "A error detected while parsing JSON data. Line 61");
        }
    }

    void getData() {
        String url = "https://api.coinstats.app/public/v1/coins?skip=0&limit=100&currency=USD";

        StringRequest request = new StringRequest(url, new Response.Listener<String>() {
            @Override
            public void onResponse(String string) {
                parseJsonData(string);
                createTableRows(tableLayout);
            }
        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError volleyError) {
                Toast.makeText(getApplicationContext(), "Some error occurred!!", Toast.LENGTH_SHORT).show();
            }
        });

        RequestQueue rQueue = Volley.newRequestQueue(MainActivity.this);
        rQueue.add(request);
    }

    void createRowWithData(CoinData coin, RelativeLayout addtoHere) {

        LinearLayout l = new LinearLayout(this);
        l.setOrientation(LinearLayout.HORIZONTAL);

        ImageView coinIcon = new ImageView(this);
        Picasso.get().load(coin.coinIconUri).resize(64,64).into(coinIcon);
        coinIcon.setPaddingRelative(20, 0,0,0);
        l.addView(coinIcon);

        TextView coinName = new TextView(this);
        coinName.setTextSize(11);
        coinName.setPaddingRelative(10, 15, 0, 0);
        coinName.setTextColor(Color.rgb(255, 255, 255));
        coinName.setText(coin.coinName);
        l.addView(coinName);

        addtoHere.addView(l);

        TextView coinPrice = new TextView(this);
        coinPrice.setTextSize(12);
        coinPrice.setGravity(Gravity.CENTER_HORIZONTAL);
        coinPrice.setPaddingRelative(0,10,0,0);
        coinPrice.setTextColor(Color.rgb(255, 255, 255));
        coinPrice.setText("$" + coin.coinPrice.toString());

        RelativeLayout.LayoutParams relativeLayoutParams1 = new RelativeLayout.LayoutParams(
                RelativeLayout.LayoutParams.WRAP_CONTENT,
                RelativeLayout.LayoutParams.WRAP_CONTENT);
        relativeLayoutParams1.addRule(RelativeLayout.CENTER_HORIZONTAL);
        addtoHere.addView(coinPrice, relativeLayoutParams1);

        TextView coinChange1d = new TextView(this);
        coinChange1d.setTextSize(17);
        coinChange1d.setGravity(Gravity.RIGHT);
        coinChange1d.setPaddingRelative(0, 0, 30, 0);

        String change = "%" + coin.coinChange1d.toString();
        coinChange1d.setText(change);

        int changeColor = coin.coinChange1d < 0 ? downColor : upColor;
        coinChange1d.setTextColor(changeColor);

        RelativeLayout.LayoutParams relativeLayoutParams2 = new RelativeLayout.LayoutParams(
                RelativeLayout.LayoutParams.WRAP_CONTENT,
                RelativeLayout.LayoutParams.WRAP_CONTENT);
        relativeLayoutParams2.addRule(RelativeLayout.ALIGN_PARENT_RIGHT);
        addtoHere.addView(coinChange1d, relativeLayoutParams2);

        addtoHere.setPaddingRelative(0,15,0,0);
    }


    void createTableRows(TableLayout tl) {
        for (CoinData coin : coinDataList) {
            TableRow tr = new TableRow(this);
            tr.setMinimumHeight(100);
            tr.setBackground(ContextCompat.getDrawable(getApplicationContext(), R.drawable.border));

            RelativeLayout r = new RelativeLayout(this);
            r.setLayoutParams(new TableRow.LayoutParams(TableRow.LayoutParams.WRAP_CONTENT, TableRow.LayoutParams.WRAP_CONTENT));
            createRowWithData(coin, r);

            tr.addView(r);
            tl.addView(tr);
        }
    }

    public void gotoPage(View view) {
        Intent intent = new Intent(this, converter.class);
        startActivity(intent);
    }
}