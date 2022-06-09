## Attentions:

### 1-) Setting coin variables

```jsx
let data = `trade=SHIBUSDT&unit=TRY&charsAfterComma=8&currencyPriceRounding=7`;
```

- trade: A variable that tells between which cryptocurrencies the swap takes place. For examples: ADAUSDT, ETHUSDT, ETHTRY, BTCTRY
- unit: The coin is first displayed with the cryptocurrency where the exchange took place. Then, the price in TL or $ units is displayed on the bottom line. Options: TRY, USDT
- charsAfterComma: You specify how many digits you want to see after the comma in numbers.
- currencyPriceRounding: For coins with more than 0, such as SHIBUSDT, we have changed this situation and left it in your hands, while normally leaving 2 numbers after the maximum comma by default. 7 is good for Shiba.

### 2-) Coin symbols

```html
<table>
  <tr>
    <td>SHIB Coin Price:</td>
    <td></td>
  </tr>
  <tr>
    <td>SHIB Coin 24 Hour Change:</td>
    <td></td>
  </tr>
 <tr>
    <td>SHIB Coin 24H HIGH:</td>
    <td></td>
  </tr>
  <tr>
    <td>SHIB Coin 24H LOW:</td>
    <td></td>
  </tr>
  <tr>
    <td>SHIB Coin 24H VOLUME(SHIB):</td>
    <td></td>
  </tr>
  <tr>
    <td>SHIB Coin 24H VOLUME(USDT):</td>
    <td></td>
  </tr>
</table>

<span id="descriptionArticle">SHIB coin today price: <span style="color: red">,</span> 24 hour change
  <span style="color: red">%,</span> 24 hour volume <span style="color: red"></span></span>
```

- Although the template is loaded in the range of 0-1 seconds after the page is loaded, we wanted it not to be empty before the template is loaded. For this, there are some details that we wrote with our own hand.
- As you can see [here](https://github.com/bgebes/binance-live-chart-application-php/blob/gh-pages/index.php), there are a lot of `SHIB` and `USDT` symbols. However, since these symbols will change every time you use different swap links, we have to fix them ourselves. For example: when we use the swap link `ETHBNB`; We should write `ETH` instead of `SHIB` and `USDT` instead of `BNB`.
- You make all of these adjustments to make it look nicer and more convenient to the user. These edits have no effect on the bot you have made.
