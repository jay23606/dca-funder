using System;

namespace dca_funder
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class DealRoot
    {
        public int id { get; set; }
        public string type { get; set; }
        public int bot_id { get; set; }
        public int max_safety_orders { get; set; }
        public bool deal_has_error { get; set; }
        public int from_currency_id { get; set; }
        public int to_currency_id { get; set; }
        public int account_id { get; set; }
        public int active_safety_orders_count { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public object closed_at { get; set; }

        //[JsonProperty("finished?")]
        public bool Finished { get; set; }
        public int current_active_safety_orders_count { get; set; }
        public int current_active_safety_orders { get; set; }
        public int completed_safety_orders_count { get; set; }
        public int completed_manual_safety_orders_count { get; set; }

        //[JsonProperty("cancellable?")]
        public bool Cancellable { get; set; }

        //[JsonProperty("panic_sellable?")]
        public bool PanicSellable { get; set; }
        public bool trailing_enabled { get; set; }
        public bool tsl_enabled { get; set; }
        public bool stop_loss_timeout_enabled { get; set; }
        public int stop_loss_timeout_in_seconds { get; set; }
        public int active_manual_safety_orders { get; set; }
        public string pair { get; set; }
        public string status { get; set; }
        public string localized_status { get; set; }
        public string take_profit { get; set; }
        public string base_order_volume { get; set; }
        public string safety_order_volume { get; set; }
        public string safety_order_step_percentage { get; set; }
        public string leverage_type { get; set; }
        public object leverage_custom_value { get; set; }
        public string bought_amount { get; set; }
        public string bought_volume { get; set; }
        public string bought_average_price { get; set; }
        public string base_order_average_price { get; set; }
        public string sold_amount { get; set; }
        public string sold_volume { get; set; }
        public string sold_average_price { get; set; }
        public string take_profit_type { get; set; }
        public string final_profit { get; set; }
        public string martingale_coefficient { get; set; }
        public string martingale_volume_coefficient { get; set; }
        public string martingale_step_coefficient { get; set; }
        public string stop_loss_percentage { get; set; }
        public object error_message { get; set; }
        public string profit_currency { get; set; }
        public string stop_loss_type { get; set; }
        public string safety_order_volume_type { get; set; }
        public string base_order_volume_type { get; set; }
        public string from_currency { get; set; }
        public string to_currency { get; set; }
        public string current_price { get; set; }
        public string take_profit_price { get; set; }
        public object stop_loss_price { get; set; }
        public string final_profit_percentage { get; set; }
        public string actual_profit_percentage { get; set; }
        public string bot_name { get; set; }
        public string account_name { get; set; }
        public string usd_final_profit { get; set; }
        public string actual_profit { get; set; }
        public string actual_usd_profit { get; set; }
        public object failed_message { get; set; }
        public string reserved_base_coin { get; set; }
        public string reserved_second_coin { get; set; }
        public string trailing_deviation { get; set; }
        public object trailing_max_price { get; set; }
        public object tsl_max_price { get; set; }
        public string strategy { get; set; }
        public string reserved_quote_funds { get; set; }
        public string reserved_base_funds { get; set; }
    }
}
