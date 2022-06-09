package coinapp.example.coinapp.models;

public class CoinData{
    public String coinName, coinIconUri;
    public Double coinPrice, coinChange1d;

    public CoinData(String coinName, String coinIconUri, Double coinPrice, Double coinChange1d) {
        this.coinName = coinName;
        this.coinIconUri = coinIconUri;
        this.coinPrice = coinPrice;
        this.coinChange1d = coinChange1d;
    }
}