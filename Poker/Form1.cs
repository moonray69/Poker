
using Poker.Models;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Poker
{
    public partial class Form1 : Form
    {
        int countMoves = 0;
        Poker.Move computerMove;
        static string CARD_IMG = @"C:\Users\Acer\Desktop\cards\PlayingCards\PNG-cards-1.3";
        Deck deck = new Deck();
        bool openCard = false;
        int balancePc = 1000;
        private bool isUser = true;
        private int rate = 5;
        private Card[] board = new Card[5];
        private Card[] Pc = new Card[2];
        private Card[] PlayerCard = new Card[2];
        int raiseBet = 0;
        private bool isUserAllIn = false;
        Move playerMove = Poker.Move.Check;


        public Form1(string nickname)
        {
            InitializeComponent();

            string playernick = "Nickname";

            label1.Text = nickname;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckingCombinations combinations = new CheckingCombinations();
            
            deck.Shuffle();
            //тягнемо 2 карти собі
            Card mycard1 = deck.DrawCard();
            Card mycard2 = deck.DrawCard();

            PlayerCard[0] = mycard1;
            PlayerCard[1] = mycard2;

            //тягнемо 3 карти на стіл
            Card tablecard1 = deck.DrawCard();
            Card tablecard2 = deck.DrawCard();
            Card tablecard3 = deck.DrawCard();
            Player.currentPlayer.Balance -= rate;
            balancePc -= rate;
            board[0] = tablecard1;
            board[1] = tablecard2;
            board[2] = tablecard3;

            //pc cards
            Card pcCard1 = deck.DrawCard();
            Card pcCard2 = deck.DrawCard();

            Pc[0] = pcCard1;
            Pc[1] = pcCard2;

            //вказуємо шлях до зображень карт 
            string CARD_IMG = @"C:\Users\Acer\Desktop\cards\PlayingCards\PNG-cards-1.3";

            //виведемо наші дві карти

            pictureBox6.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{mycard1.GetImgFileName()}");
            pictureBox7.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{mycard2.GetImgFileName()}");

            //виводимо 3 карти на стіл
            pictureBox5.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{tablecard1.GetImgFileName()}");
            pictureBox1.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{tablecard2.GetImgFileName()}");
            pictureBox2.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{tablecard3.GetImgFileName()}");
            label2.Text = rate.ToString();
            label3.Text = rate.ToString();
            // pictureBox4.BackgroundImage = Image.
            //вивести свої дві карти і 3 карти на стіл, а карти бота не показувать 
            //Card card1 = new Card(Suit.Spades, Rank.Ten, "");
            //Card card2 = new Card(Suit.Hearts, Rank.Ten, "");
            //Card card3 = new Card(Suit.Diamonds, Rank.Jack, "");
            //Card card4 = new Card(Suit.Clubs, Rank.Queen, "");
            //Card card5 = new Card(Suit.Diamonds, Rank.Eight, "");

            //List<Card> cards2 = new List<Card> { card1, card2, card3, card4, card5 };

            //label1.Text = combinations.isSeniorCards(cards2).ToString();
            label6.Text = Player.currentPlayer.Balance + " chips";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game Over, you leave the game");
            playerMove = Poker.Move.Fold;
            isUser = false;
            fuseButton();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            MessageBox.Show("");
            isUser = false;
            fuseButton();
            pcMove();
            playerMove = Poker.Move.Check;
            openCards();
        }

        private void pcMove()
        {
            bool shouldARaise = false;
            bool hasEnoughMoney = true;
            if (playerMove.Equals(Poker.Move.Raise) && playerMove.Equals(Poker.Move.Allin))
            {
                shouldARaise = true;
                //користувач пдівищив на 50 а в комп'ютера лише 20 фішок перевірити цю ситуацію
                //hasEnoughMoney якщо пк не має достатньо грошей то він зможе піти в олл ин або паснути
                if (raiseBet > balancePc)
                {
                    hasEnoughMoney = false;
                }
            }
            
            int prob = probabilityOfWin();
            Random random = new Random();
            int move = random.Next(0, 100);
            int[] Points = { 5, 10, 20, 50 };
            
            if (prob <= 12)
            {
                if (shouldARaise)
                {
                    if (!hasEnoughMoney)
                    {
                        if (move < 50)
                        {
                            computerMove = Poker.Move.Allin;
                        }
                        else
                        {
                            computerMove = Poker.Move.Fold;
                        }
                    }
                    else
                    {
                        if (move < 45)
                        {
                            computerMove = Poker.Move.Fold;


                        }
                        else if (move < 95)
                        {
                            computerMove = Poker.Move.Raise;

                        }
                        else
                        {
                            computerMove = Poker.Move.Allin;

                        }
                    }
                }
                else
                {
                    if (move < 30)
                    {
                        computerMove = Poker.Move.Fold;
                    }
                    else if (move < 60)
                    {
                        computerMove = Poker.Move.Check;
                    }
                    else if (move < 85)
                    {
                        computerMove = Poker.Move.Raise;
                    }
                    else
                    {
                        computerMove = Poker.Move.Allin;
                    }
                }
            }
            else if (prob <= 40)
            {
                //if (move < 20)
                //{
                //    computerMove = Poker.Move.Fold;
                //}
                //else if (move < 55)
                //{
                //    computerMove = Poker.Move.Check;
                //}
                //else if (move < 90)
                //{
                //    computerMove = Poker.Move.Raise;
                //}
                //else
                //{
                //    computerMove = Poker.Move.Allin;
                //}
                if (shouldARaise)
                {
                    if (!hasEnoughMoney)
                    {
                        if (move < 50)
                        {
                            computerMove = Poker.Move.Allin;
                        }
                        else
                        {
                            computerMove = Poker.Move.Fold;
                        }
                    }
                    else
                    {
                        if (move < 45)
                        {
                            computerMove = Poker.Move.Fold;
                        }
                        else if (move < 95)
                        {
                            computerMove = Poker.Move.Raise;
                        }
                        else
                        {
                            computerMove = Poker.Move.Allin;
                        }
                    }
                }
                else
                {
                    if (move < 20)
                    {
                        computerMove = Poker.Move.Fold;
                    }
                    else if (move < 55)
                    {
                        computerMove = Poker.Move.Check;
                    }
                    else if (move < 90)
                    {
                        computerMove = Poker.Move.Raise;
                    }
                    else
                    {
                        computerMove = Poker.Move.Allin;
                    }
                }
            }
            else
            {
                if (shouldARaise)
                {
                    if (!hasEnoughMoney)
                    {
                        if (move < 70)
                        {
                            computerMove = Poker.Move.Allin;
                        }
                        else
                        {
                            computerMove = Poker.Move.Fold;
                        }
                    }
                    else
                    {
                        if (move < 15)
                        {
                            computerMove = Poker.Move.Fold;
                        }
                        else if (move < 80)
                        {
                            computerMove = Poker.Move.Raise;
                        }
                        else
                        {
                            computerMove = Poker.Move.Allin;
                        }
                    }
                }
                else
                {
                    if (move < 5)
                    {
                        computerMove = Poker.Move.Fold;
                    }
                    else if (move < 40)
                    {
                        computerMove = Poker.Move.Check;
                    }
                    else if (move < 70)
                    {
                        computerMove = Poker.Move.Raise;
                    }
                    else
                    {
                        computerMove = Poker.Move.Allin;
                    }
                }
            }
            //if (prob <= 12)
            //{
            //    if (shouldARaise)
            //    {
            //        if (!hasEnoughMoney)
            //        {
            //            if (move < 50)
            //            {
            //                label4.Text = "All in";
            //                label3.Text = rate.ToString();
            //            }
            //            else
            //            {
            //                label4.Text = "Fold in";
            //                pictureBox9.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[0].GetImgFileName()}");
            //                pictureBox8.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[0].GetImgFileName()}");
            //            }
            //        }
            //        else
            //        {
            //            if (move < 45)
            //            {
            //                label4.Text = "Fold In";
            //                pictureBox9.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[0].GetImgFileName()}");
            //                pictureBox8.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[1].GetImgFileName()}");
            //                MessageBox.Show("Game Over");
            //                Player.currentPlayer.Balance += rate - raiseBet;
            //            }
            //            else if (move < 95)
            //            {
            //                label4.Text = $"Bot raise bet to: {rate} chips";
            //                //як сюди можна прикрутити чи користувач підняв ставку якщо користувач підняв ставку то ми можемо зробити або fold in abo raise abo allin
            //                balancePc -= rate;
            //                Player.currentPlayer.Balance += rate;
            //            }
            //            else
            //            {
            //                label4.Text = $"Bot go to the All in bet: {balancePc + rate} chips";
            //                raiseBet = balancePc;
            //                rate += raiseBet;
            //                balancePc = 0;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (move < 30)
            //        {
            //            label4.Text = "Fold In";
            //            pictureBox9.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[0].GetImgFileName()}");
            //            pictureBox8.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[1].GetImgFileName()}");
            //        }
            //        else if (move < 60)
            //        {
            //            label4.Text = "Check";

            //        }
            //        else if (move < 85)
            //        {
            //            label4.Text = "Raise";

            //            //як сюди можна прикрутити чи користувач підняв ставку якщо користувач підняв ставку то ми можемо зробити або fold in abo raise abo allin
            //            balancePc -= rate;
            //            Player.currentPlayer.Balance += rate;
            //        }
            //        else
            //        {
            //            label4.Text = "All in";
            //        }
            //    }
            //}
            //else if (prob <= 40)
            //{
            //    if (move < 20)
            //    {
            //        label4.Text = "Fold In";
            //        pictureBox9.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[0].GetImgFileName()}");
            //        pictureBox8.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[1].GetImgFileName()}");
            //        balancePc -= rate;
            //        Player.currentPlayer.Balance += rate;
            //    }
            //    else if (move < 55)
            //    {
            //        label4.Text = "Check";
            //    }
            //    else if (move < 90)
            //    {
            //        label4.Text = $"Bot raise bet to: {rate} chips";//to do
            //    }
            //    else
            //    {
            //        label4.Text = "All in";
            //    }
            //}
            //else
            //{
            //    if (move < 5)
            //    {
            //        label4.Text = "Fold In";
            //        pictureBox9.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[0].GetImgFileName()}");
            //        pictureBox8.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[1].GetImgFileName()}");
            //        balancePc -= rate;
            //        Player.currentPlayer.Balance += rate;
            //    }
            //    else if (move < 40)
            //    {
            //        label4.Text = "Check";
            //    }
            //    else if (move < 70)
            //    {
            //        label4.Text = "Raise";
            //    }
            //    else
            //    {
            //        label4.Text = "All in";
            //    }
            //}

            if (computerMove.Equals(Poker.Move.Fold))
            {
                label4.Text = "Fold In";
                pictureBox9.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[0].GetImgFileName()}");
                pictureBox8.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{Pc[1].GetImgFileName()}");
                Player.currentPlayer.Balance += rate;
            }
            else if (computerMove.Equals(Poker.Move.Check))
            {
                label4.Text = "Check";
            }
            else if(computerMove.Equals(Poker.Move.Raise))
            {
                label4.Text = "Raise";

                //наскільки піднімає бот докрутити 
                balancePc -= rate;
                Player.currentPlayer.Balance += rate;
            }
            else
            {
                label4.Text = $"Bot go to the All in bet: {balancePc + rate} chips";
                raiseBet = balancePc;
                rate += raiseBet;
                balancePc = 0;
            }
            if (label4.Text.Contains("All in") || label4.Text.ToLower().Contains("raise"))
            {
                label3.Text = rate.ToString();
            }
            
            isUser = true;
            fuseButton();
         
        }
        public void openCards()
        {
            //if (!openCard)
            //{
            //    return;
            //}
            if (playerMove == Poker.Move.Check && computerMove == Poker.Move.Check)
            {
                if (board[3] == null)
                {
                    board[3] = deck.DrawCard();
                    pictureBox3.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[3].GetImgFileName()}");
                }
                else
                {
                    board[4] = deck.DrawCard();
                    pictureBox4.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[4].GetImgFileName()}");
                }
            }
            else if (playerMove == Poker.Move.Raise && (computerMove == Poker.Move.Raise || computerMove == Poker.Move.Allin))
            {
                if (board[3] == null)
                {
                    board[3] = deck.DrawCard();
                    pictureBox3.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[3].GetImgFileName()}");
                }
                else
                {
                    board[4] = deck.DrawCard();
                    pictureBox4.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[4].GetImgFileName()}");
                }
            }
            else if (playerMove == Poker.Move.Allin && (computerMove == Poker.Move.Raise || computerMove == Poker.Move.Allin))
            {
                if (board[3] == null)
                {
                    board[3] = deck.DrawCard();
                    pictureBox3.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[3].GetImgFileName()}");
                }
                else
                {
                    board[4] = deck.DrawCard();
                    pictureBox4.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[4].GetImgFileName()}");
                }
            }
            openCard = false;
        }

        private CombinationCards checkCombination()
        {
            CheckingCombinations combinations = new CheckingCombinations();
            //перевірити якщо на столі 3 карти робимо щось , а якщо 5 карт то щось інше 
            List<Card> cards = new List<Card>(Pc);
            if (board[3] == null)
            {
                cards.Add(board[0]);
                cards.Add(board[1]);
                cards.Add(board[2]);
            }
            else
            {
                //Range = додає колекцію 
                cards.AddRange(board);
            }
            //реалізувати перевірку комбінації і бали комбінації повертати

            if (combinations.isRoyalFlush(cards))
            {
                return CombinationCards.RoyalFlush;
            }
            else if (combinations.isStraightFlush(cards))
            {
                return CombinationCards.StraightFlush;
            }
            else if (combinations.isFourOfAKind(cards))
            {
                return CombinationCards.FourOfAKind;
            }
            else if (combinations.isFullHouse(cards))
            {
                return CombinationCards.FullHouse;
            }
            else if (combinations.isFlush(cards))
            {
                return CombinationCards.Flush;
            }
            else if (combinations.isStraight(cards))
            {
                return CombinationCards.Straight;
            }
            else if (combinations.isTrips(cards))
            {
                return CombinationCards.Trips;
            }
            else if (combinations.isTwoCouple(cards))
            {
                return CombinationCards.TwoPair;
            }
            else if (combinations.isCouple(cards))
            {
                return CombinationCards.Pair;
            }
            else
            {
                return CombinationCards.Senior;
            }

        }

        private int probabilityOfWin()
        {
            List<Card> cards = new List<Card>(Pc);
            if (board[3] == null)
            {
                cards.Add(board[0]);
                cards.Add(board[1]);
                cards.Add(board[2]);
            }
            else
            {
                //Range = додає колекцію 
                cards.AddRange(board);
            }
            CombinationCards result = checkCombination();

            if (!result.Equals(CombinationCards.Senior))
            {
                return ((int)result + 1) * 10;
            }
            else
            {
                CheckingCombinations combinations = new CheckingCombinations();
                return combinations.isSeniorCards(cards);
            }
        }

        private void fuseButton()
        {
            if (isUser)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            isUser = false;
            RaiseForm raise = new RaiseForm();
            raise.ShowDialog();
            raiseBet = raise.bet;
            Player.currentPlayer.Balance -= raiseBet;
            rate += raiseBet;
            label5.Text = $"User raise bet to: {rate} chips";
            label6.Text = Player.currentPlayer.Balance + " chips";
            label2.Text = rate.ToString();
            playerMove = Poker.Move.Raise;
            fuseButton();
            pcMove();
            countMoves++;
            openCards();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //перевірка чи зможе користувач піти в олин 2 раз
            if (isUserAllIn)
            {
                MessageBox.Show("You have already set everything up");
            }
            else
            {
                isUser = false;
                isUserAllIn = true;
                label5.Text = $"User go to the ALLIN bet: {Player.currentPlayer.Balance + rate} chips";
                rate += Player.currentPlayer.Balance;
                raiseBet = Player.currentPlayer.Balance;
                Player.currentPlayer.Balance = 0;
                fuseButton();
                label6.Text = Player.currentPlayer.Balance + " chips";
                label2.Text = rate.ToString();
                playerMove = Poker.Move.Allin;
                pcMove();
                openCards();
            }
        }
    }
}