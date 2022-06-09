<?php
ini_set("allow_url_fopen", 1);
$GLOBALS['binanceAPI'] = "https://api.binance.com/api/v3/ticker/24hr?symbol=";
$GLOBALS['currencyList'] = $GLOBALS['coinInfo'] = [];
$GLOBALS['unitCharacter'] = "";

function startGettingData($trade, $unit, $charsAfterComma, $currencyPriceRounding)
{
  switch ($unit) {
    case "USDT":
      $GLOBALS['unitCharacter'] = "$";
      break;
    case "TRY":
      $GLOBALS['unitCharacter'] = "TL";
      break;
    case "EUR":
      $GLOBALS['unitCharacter'] = "£";
      break;
    default:
      $GLOBALS['unitCharacter'] = $unit;
  }

  $text = "BTC,ETH,BNB,TRX,XRP,USDT,BUSD,BRL,AUD,BIDR,EUR,GBP,RUB,TRY,TUSD,USDC,DAI,IDRT,PAX,UAH,NGN,VAI,BVND";
  $GLOBALS['currencyList'] = explode(',', $text);
  $coinURL = $GLOBALS['binanceAPI'] . $trade;
  $lastPriceInfo = getCoinInfo($coinURL, $charsAfterComma);
  $lastCurrencyInfo = getCurrencyURL($trade, $unit);
  $coinPrice = $lastPriceInfo['lastPrice'];
  $unitBool = $lastCurrencyInfo['tempBool'];
  $currencyURL = $lastCurrencyInfo['tempURL'];

  $lastCurrencyPrice = getCurrencyPrice($currencyURL, $unitBool, $coinPrice, $currencyPriceRounding);
  $GLOBALS['coinInfo'] = [
    "coinSymbol" => $lastCurrencyInfo['coinSymbol'],
    "currency" => $lastCurrencyInfo['currency'],
    "lastPrice" => $lastPriceInfo['lastPrice'],
    "lastPriceWithUnit" => $lastCurrencyPrice,
    "change24hrPrice" => $lastPriceInfo['change24hrPrice'],
    "change24hrPercent" => $lastPriceInfo['change24hrPercent'],
    "highPrice24hr" => $lastPriceInfo['highPrice24hr'],
    "lowPrice24hr" => $lastPriceInfo['lowPrice24hr'],
    "volumeWithLot24hr" => $lastPriceInfo['volumeWithLot24hr'],
    "volumeWithCurrency24hr" => $lastPriceInfo['volumeWithCurrency24hr']
  ];
}

function getCoinInfo($url, $roundingTime)
{
  $json = file_get_contents($url);
  $obj = json_decode($json);

  $tempInfo = [
    "lastPrice" => rounding($obj->lastPrice, $roundingTime),
    "change24hrPrice" => rounding($obj->priceChange, $roundingTime),
    "change24hrPercent" => rounding($obj->priceChangePercent, 2),
    "highPrice24hr" => rounding($obj->highPrice, $roundingTime),
    "lowPrice24hr" => rounding($obj->lowPrice, $roundingTime),
    "volumeWithLot24hr" => rounding($obj->volume, 2),
    "volumeWithCurrency24hr" => rounding($obj->quoteVolume, 2)
  ];

  return $tempInfo;
}

function getCurrencyURL($coinTradeSymbol, $unit)
{
  $specialList = ["BRL", "BIDR", "RUB", "TRY", "DAI", "IDRT", "UAH", "NGN", "BVND"];
  $tempBool = false;
  $tempInfo = [
    "currency" => "abc",
    "coinSymbol" => "abc",
    "tempURL" => "abc",
    "tempBool" => false
  ];

  for ($i = 0; $i < count($GLOBALS['currencyList']); $i++) {
    $tempCurrency = $GLOBALS['currencyList'][$i];
    $bool1 = contaning($coinTradeSymbol, $tempCurrency);
    $bool2 = isCurrency($coinTradeSymbol, $tempCurrency);
    $final = $bool1 && $bool2;
    if ($final && $tempCurrency != $unit) {
      if (in_array($tempCurrency, $specialList)) {
        $tempURL = $GLOBALS['binanceAPI'] . $unit . $tempCurrency;
        $tempBool = true;
      } else if (in_array($unit, $specialList)) {
        $tempURL = $GLOBALS['binanceAPI'] . $tempCurrency . $unit;
        $tempBool = true;
      } else if ($tempCurrency == "EUR") {
        $tempURL = $GLOBALS['binanceAPI'] . $tempCurrency . $unit;
      } else if ($unit == "EUR") {
        $tempURL = $GLOBALS['binanceAPI'] . $unit . $tempCurrency;
      } else {
        $tempURL = $GLOBALS['binanceAPI'] . $tempCurrency . $unit;
        $tempBool = true;
      }

      $tempInfo['currency'] = $tempCurrency;
      $tempInfo['coinSymbol'] = explode($tempCurrency, $coinTradeSymbol)[0];
      $tempInfo['tempURL']  = $tempURL;
      $tempInfo['tempBool'] = $tempBool;
    } else if ($final && $tempCurrency == $unit) {
      $tempInfo['currency'] = $tempCurrency;
      $tempInfo['coinSymbol'] = explode($tempCurrency, $coinTradeSymbol)[0];
      echo ($tempInfo['coinSymbol']);
      $tempInfo['tempURL'] = "Not Necessary";
      $tempInfo['tempBool'] = $tempBool;
    }
  }

  return $tempInfo;
}

function getCurrencyPrice($url, $uBool, $coinPrice, $currencyPriceRounding)
{
  if ($url != "Not Necessary") {
    $json = file_get_contents($url);
    $obj = json_decode($json);

    $currencyPrice = $obj->lastPrice;
    $tempCurrencyPrice = $uBool ? rounding($coinPrice * $currencyPrice, $currencyPriceRounding) : rounding($coinPrice / $currencyPrice, $currencyPriceRounding);
  } else {
    $tempCurrencyPrice = rounding($coinPrice, $currencyPriceRounding);
  }

  return $tempCurrencyPrice;
}

function rounding($number, $roundTime)
{
  return sprintf("%.${roundTime}f", floatval($number));
}

function contaning($main, $part)
{
  $check = strpos($main, $part) == false;
  return $check != 1;
}

function formatNumber($number)
{
  $numberParts = explode('.', $number);
  $firstSection = floatVal($numberParts[0]);
  $afterCommaSection = $numberParts[1];
  $firstSection = $number >= 1000 ? number_format($firstSection) : $firstSection;

  $result = floatVal($afterCommaSection) > 0 ? $firstSection . '.' . $afterCommaSection : $firstSection;

  return $result;
}

function arrow($percent)
{
  if (floatVal($percent) > 0) {
    return "<span style='color:green'>↑</span>";
  } else {
    return "<span style='color:red'>↓</span>";
  }
}

function isCurrency($coinTradeSymbol, $currency)
{
  $currencyCharCount = strlen($currency);
  $coinTradeSymbolCharCount = strlen($coinTradeSymbol);
  $shouldBeIndex = $coinTradeSymbolCharCount - $currencyCharCount;

  if (strpos($coinTradeSymbol, $currency) == $shouldBeIndex) {
    return true;
  } else {
    return false;
  }
}

function percentColor($percent, $price)
{
  if ($percent < 0) {
    $withPrice = "<span class='small text-danger' id='change24hrWithlot'>${price}</span>";
    $withPercent = "<span class='small text-danger' id='change24hrWithpercent'>${percent}%</span>";
    $result = $withPrice . "<br>" . $withPercent;
  } else {
    $withPrice = "<span class='small text-success' id='change24hrWithlot'>${price}</span>";
    $withPercent = "<span class='small text-success' id='change24hrWithpercent'>${percent}%</span>";
    $result = $withPrice . "<br>" . $withPercent;
  }

  return $result;
}
