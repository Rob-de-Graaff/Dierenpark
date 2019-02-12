namespace Dierenpark
{
    internal class Subscription
    {
        public Subscription(string subsciptionName, double subscriptionPricce)
        {
            Name = subsciptionName;

            price = subscriptionPricce;
        }

        public string Name { set; get; }

        public double Price
        {
            set { price = value; }
            get { return price; }
        }

        private double price;
    }
}