using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinTrader.UI
{
    public class CBudgetManager
    {
        public CBudget Budget { get; set; } = new CBudget();

        private static CBudgetManager instance = null;
        public static CBudgetManager getInstance()
        {
            if (instance == null)
                instance = new CBudgetManager();
            return instance;
        }

        

        private CBudgetManager()
        {
            instance = this;
        }

        public List<CBudgetItem> getBudgetItemList()
        {
            return Budget.Items;
        }

        public void initializeBudget(string symbol, double amount, double cost)
        {
            addToBudget(symbol, amount, cost);
        }

        /// <summary>
        /// Add to budget in BUY trade
        /// </summary>
        /// <param name="symbol">Symbol Pair</param>
        /// <param name="amount">Amount</param>
        /// <param name="cost">Cost Price</param>
        public bool addToBudget(string symbol, double amount, double cost)
        {
            if (Budget.Items.Any(i => i.Symbol.Equals(symbol)))
            {
                // Update
                CBudgetItem bi = Budget.Items.Find(i => i.Symbol.Equals(symbol));
                if (bi.Amount > amount)
                {
                    bi.AverageCost = (bi.AverageCost * bi.Amount + cost * amount) / (bi.Amount + amount);
                    bi.Amount = bi.Amount + amount;

                }
                else
                {
                    return false;
                }
                   
            }
            else
            {
                // add new
                Budget.Items.Add(new CBudgetItem()
                {
                    Symbol = symbol,
                    Amount = amount,
                    AverageCost = cost
                });
            }

            Budget.UpdateWallet();

            return true;
        }

        /// <summary>
        /// Remove from budget in SELL trade
        /// </summary>
        /// <param name="symbol">Symbol Pair</param>
        /// <param name="amount">Amount</param>
        /// <param name="cost">Cost Price</param>
        /// <returns></returns>
        public bool removeFromBudget(string symbol, double amount, double cost)
        {
            CBudgetItem bi = Budget.Items.Find(i => i.Symbol.Equals(symbol));

            if (bi == null) return false;

            if (bi.Amount > amount)
            {
                bi.AverageCost = (bi.AverageCost * bi.Amount - cost * amount) / (bi.Amount + amount);
                bi.Amount = bi.Amount - amount;
                return true;
            }

            return false;
        }
    }

    public class CBudget
    {
        public double TotalUSDInWallet { get; set; }
        public List<CBudgetItem> Items { get; set; } = new List<CBudgetItem>();

        public void UpdateWallet()
        {
            TotalUSDInWallet = 0;
            foreach (var item in Items)
            {
                TotalUSDInWallet += item.AverageCost * item.Amount;
            }
        }
    }

    public class CBudgetItem
    {
        public string Symbol { get; set; }
        public double Amount { get; set; }
        public double AverageCost { get; set; }
    }
}
