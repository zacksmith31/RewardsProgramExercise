using System;
using System.Collections.Generic;
using System.Linq;

namespace RewardsProgramExercise
{
    class RewardsProgram
    {
        class Transaction{
            public int CustomerId;
            public DateTime Timestamp = DateTime.UtcNow;
            public float Total;
            public double Points;
        }

        class TransactionLog{
            public int CustomerId;
            public List<Transaction> Transactions;
            public double TotalRewardPoints;
        }

        static void Main(string[] args)
        {
            //Sample data
            List<TransactionLog> CustomerTransactionLog  = new List<TransactionLog>()
            {
                new TransactionLog{
                    CustomerId = 1,
                    Transactions = new List<Transaction>(){
                        new Transaction{
                            CustomerId = 1,
                            Timestamp = new DateTime(2020, 01, 01),
                            Total = 100.0f
                        },
                        new Transaction{
                            CustomerId = 1,
                            Timestamp = new DateTime(2020, 02, 01),
                            Total = 200.0f
                        },
                        new Transaction{
                            CustomerId = 1,
                            Timestamp = new DateTime(2020, 03, 01),
                            Total = 60.0f
                        },
                    }
                },
                
                new TransactionLog{
                    CustomerId = 2,
                    Transactions = new List<Transaction>(){
                        new Transaction{
                            CustomerId = 2,
                            Timestamp = new DateTime(2020, 01, 01),
                            Total = 60.0f
                        },
                        new Transaction{
                            CustomerId = 2,
                            Timestamp = new DateTime(2020, 02, 01),
                            Total = 300.0f
                        },
                        new Transaction{
                            CustomerId = 2,
                            Timestamp = new DateTime(2020, 03, 01),
                            Total = 120.0f
                        },
                    },
                },

                new TransactionLog{
                    CustomerId = 3,
                    Transactions = new List<Transaction>(){
                        new Transaction{
                            CustomerId = 3,
                            Timestamp = new DateTime(2020, 01, 01),
                            Total = 75.0f
                        },
                        new Transaction{
                            CustomerId = 3,
                            Timestamp = new DateTime(2020, 02, 01),
                            Total = 500.0f
                        },
                        new Transaction{
                            CustomerId = 3,
                            Timestamp = new DateTime(2020, 03, 01),
                            Total = 160.0f
                        },
                    }
                }
            };

            //Calculate reward points
            foreach(var t in CustomerTransactionLog){
                t.Transactions.Select(x => CalculatePointsOnTransaction(x.Total));
                t.TotalRewardPoints = t.Transactions.Sum(x => x.Points);
            }

            //Output reward point balances
            Console.WriteLine("Reward Points Summary:");
            foreach(var t in CustomerTransactionLog){
                Console.WriteLine($"Customer # {t.CustomerId}");
                Console.WriteLine($"January - {t.Transactions.Where(x => x.Timestamp.Month == 1).Sum(x => x.Points)}");
                Console.WriteLine($"February - {t.Transactions.Where(x => x.Timestamp.Month == 2).Sum(x => x.Points)}");
                Console.WriteLine($"March - {t.Transactions.Where(x => x.Timestamp.Month == 3).Sum(x => x.Points)}");
                Console.WriteLine($"Total - {t.TotalRewardPoints}");
                Console.WriteLine("----------");
            }
        }

        static double CalculatePointsOnTransaction(float total){
            double pointTally = 0;
            double flooredTotal = Math.Floor(total);

            //total over 100
            if(flooredTotal / 100 > 1){
                //how many dollars over 100 do we have?
                var totalOver100 = flooredTotal - 100.00;
                //apply points
                var pointsOver100 = totalOver100 * 2;
                pointTally += pointsOver100;
            }  

            //total over 50
            if(flooredTotal / 50 > 1){
                //how many dollars over 50 do we have?
                var totalOver50 = flooredTotal - 50;
                //apply points
                var pointsOver50 = totalOver50;
                pointTally += pointsOver50;
            }

            return pointTally;
        }
    }
}
