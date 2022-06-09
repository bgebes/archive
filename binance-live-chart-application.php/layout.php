<?php
ini_set("allow_url_fopen", 1);
$trade = $_GET['trade'];
$unit = $_GET['unit'];
$charsAfterComma = $_GET['charsAfterComma'];
$currencyPriceRounding = $_GET['currencyPriceRounding'];

require("script.php");
startGettingData($trade, $unit, $charsAfterComma, $currencyPriceRounding);
$data = $GLOBALS['coinInfo'];
$data['currencyforPrice'] = $data['currency'] == 'USDT' ? '$' : $data['currency'];
?>

<table width="100%">
  <tr>
    <td><?php echo ($data["coinSymbol"]); ?> Coin Price:</td>
    <td><?php echo (formatNumber($data["lastPriceWithUnit"]) . " " . $GLOBALS['unitCharacter']); ?> (<?php echo (formatNumber($data["lastPrice"]) . " " . $data['currencyforPrice']); ?>)</td>
  </tr>
  <tr>
    <td><?php echo ($data["coinSymbol"]); ?> Coin 24 Hour Change:</td>
    <td><?php echo (arrow($data['change24hrPercent']) . " " . formatNumber($data['change24hrPercent'])); ?> % (<?php echo (formatNumber($data["change24hrPrice"]) . " " . $data["coinSymbol"]); ?>) </td>
  </tr>
  <tr>
    <td><?php echo ($data["coinSymbol"]); ?> Coin 24H HIGH:</td>
    <td><?php echo (formatNumber($data["highPrice24hr"]) . " " . $data["currencyforPrice"]); ?></td>
  </tr>
  <tr>
    <td><?php echo ($data["coinSymbol"]); ?> Coin 24H LOW:</td>
    <td><?php echo (formatNumber($data["lowPrice24hr"]) . " " . $data["currencyforPrice"]); ?></td>
  </tr>
  <tr>
    <td><?php echo ($data["coinSymbol"]); ?> Coin 24H VOLUME(<?php echo ($data["coinSymbol"]); ?>):</td>
    <td><?php echo (formatNumber($data["volumeWithLot24hr"])); ?> (<?php echo ($data["coinSymbol"]); ?>)</td>
  </tr>
  <tr>
    <td><?php echo ($data["coinSymbol"]); ?> Coin 24H VOLUME(<?php echo ($data["currency"]); ?>):</td>
    <td><?php echo (formatNumber($data["volumeWithCurrency24hr"])); ?> (<?php echo ($data["currency"]); ?>)</td>
  </tr>
</table>

<br>

<span id="descriptionArticle"><?php echo ($data["coinSymbol"]); ?> coin today price: <span style="color: red"><?php echo (formatNumber($data["lastPriceWithUnit"]) . " " . $GLOBALS['unitCharacter']); ?>,</span> 24 hour change
  <span style="color: red"><?php echo (formatNumber($data['change24hrPercent'])); ?>%,</span> 24 hour volume <span style="color: red"><?php echo (formatNumber($data["volumeWithCurrency24hr"]) . " " . $data['currencyforPrice']); ?> </span></span>