<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<script>
  $(document).ready(function() {
    let data = `trade=SHIBUSDT&unit=TRY&charsAfterComma=8&currencyPriceRounding=7`;
    setInterval(function() {
      $("#priceTable").load(`layout.php?${data}`);
    }, 500);
  });
</script>

<div id="priceTable">
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

  <br>

  <span id="descriptionArticle">SHIB coin today price: <span style="color: red">,</span> 24 hour change
    <span style="color: red">%,</span> 24 hour volume <span style="color: red"></span></span>
</div>