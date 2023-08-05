using System.Text.Json.Serialization;

#pragma warning disable CS8618

namespace Rub2KztRatesBot.Binance;

public partial class BinanceAdvertisementsResponse
{
    [JsonPropertyName("code")] public string Code { get; set; }

    [JsonPropertyName("message")] public object Message { get; set; }

    [JsonPropertyName("messageDetail")] public object MessageDetail { get; set; }

    [JsonPropertyName("data")] public Datum[] Data { get; set; }

    [JsonPropertyName("total")] public long Total { get; set; }

    [JsonPropertyName("success")] public bool Success { get; set; }
}

public partial class Datum
{
    [JsonPropertyName("adv")] public Adv Adv { get; set; }

    [JsonPropertyName("advertiser")] public Advertiser Advertiser { get; set; }
}

public partial class Adv
{
    [JsonPropertyName("advNo")] public string AdvNo { get; set; }

    [JsonPropertyName("classify")] public string Classify { get; set; }

    [JsonPropertyName("tradeType")] public string TradeType { get; set; }

    [JsonPropertyName("asset")] public string Asset { get; set; }

    [JsonPropertyName("fiatUnit")] public string FiatUnit { get; set; }

    [JsonPropertyName("advStatus")] public object AdvStatus { get; set; }

    [JsonPropertyName("priceType")] public object PriceType { get; set; }

    [JsonPropertyName("priceFloatingRatio")]
    public object PriceFloatingRatio { get; set; }

    [JsonPropertyName("rateFloatingRatio")]
    public object RateFloatingRatio { get; set; }

    [JsonPropertyName("currencyRate")] public object CurrencyRate { get; set; }

    [JsonPropertyName("price")] public string Price { get; set; }

    [JsonPropertyName("initAmount")] public object InitAmount { get; set; }

    [JsonPropertyName("surplusAmount")] public string SurplusAmount { get; set; }

    [JsonPropertyName("amountAfterEditing")]
    public object AmountAfterEditing { get; set; }

    [JsonPropertyName("maxSingleTransAmount")]
    public string MaxSingleTransAmount { get; set; }

    [JsonPropertyName("minSingleTransAmount")]
    public string MinSingleTransAmount { get; set; }

    [JsonPropertyName("buyerKycLimit")] public object BuyerKycLimit { get; set; }

    [JsonPropertyName("buyerRegDaysLimit")]
    public object BuyerRegDaysLimit { get; set; }

    [JsonPropertyName("buyerBtcPositionLimit")]
    public object BuyerBtcPositionLimit { get; set; }

    [JsonPropertyName("remarks")] public object Remarks { get; set; }

    [JsonPropertyName("autoReplyMsg")] public string AutoReplyMsg { get; set; }

    [JsonPropertyName("payTimeLimit")] public object PayTimeLimit { get; set; }

    [JsonPropertyName("tradeMethods")] public TradeMethod[] TradeMethods { get; set; }

    [JsonPropertyName("userTradeCountFilterTime")]
    public object UserTradeCountFilterTime { get; set; }

    [JsonPropertyName("userBuyTradeCountMin")]
    public object UserBuyTradeCountMin { get; set; }

    [JsonPropertyName("userBuyTradeCountMax")]
    public object UserBuyTradeCountMax { get; set; }

    [JsonPropertyName("userSellTradeCountMin")]
    public object UserSellTradeCountMin { get; set; }

    [JsonPropertyName("userSellTradeCountMax")]
    public object UserSellTradeCountMax { get; set; }

    [JsonPropertyName("userAllTradeCountMin")]
    public object UserAllTradeCountMin { get; set; }

    [JsonPropertyName("userAllTradeCountMax")]
    public object UserAllTradeCountMax { get; set; }

    [JsonPropertyName("userTradeCompleteRateFilterTime")]
    public object UserTradeCompleteRateFilterTime { get; set; }

    [JsonPropertyName("userTradeCompleteCountMin")]
    public object UserTradeCompleteCountMin { get; set; }

    [JsonPropertyName("userTradeCompleteRateMin")]
    public object UserTradeCompleteRateMin { get; set; }

    [JsonPropertyName("userTradeVolumeFilterTime")]
    public object UserTradeVolumeFilterTime { get; set; }

    [JsonPropertyName("userTradeType")] public object UserTradeType { get; set; }

    [JsonPropertyName("userTradeVolumeMin")]
    public object UserTradeVolumeMin { get; set; }

    [JsonPropertyName("userTradeVolumeMax")]
    public object UserTradeVolumeMax { get; set; }

    [JsonPropertyName("userTradeVolumeAsset")]
    public object UserTradeVolumeAsset { get; set; }

    [JsonPropertyName("createTime")] public object CreateTime { get; set; }

    [JsonPropertyName("advUpdateTime")] public object AdvUpdateTime { get; set; }

    [JsonPropertyName("fiatVo")] public object FiatVo { get; set; }

    [JsonPropertyName("assetVo")] public object AssetVo { get; set; }

    [JsonPropertyName("advVisibleRet")] public object AdvVisibleRet { get; set; }

    [JsonPropertyName("assetLogo")] public object AssetLogo { get; set; }

    [JsonPropertyName("assetScale")] public long AssetScale { get; set; }

    [JsonPropertyName("fiatScale")] public long FiatScale { get; set; }

    [JsonPropertyName("priceScale")] public long PriceScale { get; set; }

    [JsonPropertyName("fiatSymbol")] public string FiatSymbol { get; set; }

    [JsonPropertyName("isTradable")] public bool IsTradable { get; set; }

    [JsonPropertyName("dynamicMaxSingleTransAmount")]
    public string DynamicMaxSingleTransAmount { get; set; }

    [JsonPropertyName("minSingleTransQuantity")]
    public string MinSingleTransQuantity { get; set; }

    [JsonPropertyName("maxSingleTransQuantity")]
    public string MaxSingleTransQuantity { get; set; }

    [JsonPropertyName("dynamicMaxSingleTransQuantity")]
    public string DynamicMaxSingleTransQuantity { get; set; }

    [JsonPropertyName("tradableQuantity")] public string TradableQuantity { get; set; }

    [JsonPropertyName("commissionRate")] public string CommissionRate { get; set; }

    [JsonPropertyName("tradeMethodCommissionRates")]
    public object[] TradeMethodCommissionRates { get; set; }

    [JsonPropertyName("launchCountry")] public object LaunchCountry { get; set; }

    [JsonPropertyName("abnormalStatusList")]
    public object AbnormalStatusList { get; set; }

    [JsonPropertyName("closeReason")] public object CloseReason { get; set; }

    public decimal PriceDecimal => decimal.Parse(Price);
}

public partial class TradeMethod
{
    [JsonPropertyName("payId")] public object PayId { get; set; }

    [JsonPropertyName("payMethodId")] public string PayMethodId { get; set; }

    [JsonPropertyName("payType")] public object PayType { get; set; }

    [JsonPropertyName("payAccount")] public object PayAccount { get; set; }

    [JsonPropertyName("payBank")] public object PayBank { get; set; }

    [JsonPropertyName("paySubBank")] public object PaySubBank { get; set; }

    [JsonPropertyName("identifier")] public string Identifier { get; set; }

    [JsonPropertyName("iconUrlColor")] public object IconUrlColor { get; set; }

    [JsonPropertyName("tradeMethodName")] public string TradeMethodName { get; set; }

    [JsonPropertyName("tradeMethodShortName")]
    public string TradeMethodShortName { get; set; }

    [JsonPropertyName("tradeMethodBgColor")]
    public string TradeMethodBgColor { get; set; }
}

public partial class Advertiser
{
    [JsonPropertyName("userNo")] public string UserNo { get; set; }

    [JsonPropertyName("realName")] public object RealName { get; set; }

    [JsonPropertyName("nickName")] public string NickName { get; set; }

    [JsonPropertyName("margin")] public object Margin { get; set; }

    [JsonPropertyName("marginUnit")] public object MarginUnit { get; set; }

    [JsonPropertyName("orderCount")] public object OrderCount { get; set; }

    [JsonPropertyName("monthOrderCount")] public long MonthOrderCount { get; set; }

    [JsonPropertyName("monthFinishRate")] public double MonthFinishRate { get; set; }

    [JsonPropertyName("advConfirmTime")] public object AdvConfirmTime { get; set; }

    [JsonPropertyName("email")] public object Email { get; set; }

    [JsonPropertyName("registrationTime")] public object RegistrationTime { get; set; }

    [JsonPropertyName("mobile")] public object Mobile { get; set; }

    [JsonPropertyName("userType")] public string UserType { get; set; }

    [JsonPropertyName("tagIconUrls")] public object[] TagIconUrls { get; set; }

    [JsonPropertyName("userGrade")] public long UserGrade { get; set; }

    [JsonPropertyName("userIdentity")] public string UserIdentity { get; set; }

    [JsonPropertyName("proMerchant")] public object ProMerchant { get; set; }

    [JsonPropertyName("isBlocked")] public object IsBlocked { get; set; }
}