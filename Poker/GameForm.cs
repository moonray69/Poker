
using Poker.Models;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Poker
{
    public partial class GameForm : Form
    {
        Player pc = new Player { Nickname = "Bob", Balance = 1000 };
        int countMoves = 0;
        //вказуємо шлях до зображень карт 
        static string CARD_IMG = @"C:\Users\Acer\Desktop\cards\PlayingCards\PNG-cards-1.3";
        Deck deck = new Deck();

        bool openCard = false;
        private bool isUser = true;
        private int rate = 5;
        private Card[] board = new Card[5];
        int raiseBet = 0;


        public GameForm(string nickname)
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

            Player.currentPlayer.Cards[0] = mycard1;
            Player.currentPlayer.Cards[1] = mycard2;

            //тягнемо 3 карти на стіл
            Card tablecard1 = deck.DrawCard();
            Card tablecard2 = deck.DrawCard();
            Card tablecard3 = deck.DrawCard();
            Player.currentPlayer.Balance -= rate;
            pc.Balance -= rate;
            board[0] = tablecard1;
            board[1] = tablecard2;
            board[2] = tablecard3;

            //pc cards
            Card pcCard1 = deck.DrawCard();
            Card pcCard2 = deck.DrawCard();


            pc.Cards[0] = pcCard1;
            pc.Cards[1] = pcCard2;


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
            CombinationForm form = new CombinationForm();
            form.ShowDialog();
        }

        private void foldButtonClick(object sender, EventArgs e)
        {
            MessageBox.Show("Game Over, you leave the game");
            Player.currentPlayer.LastMove = Moves.Fold;
            isUser = false;
            fuseButton();
        }

        private void checkButtonClick(object sender, EventArgs e)
        {
            Player.currentPlayer.LastMove = Moves.Check;
            isUser = false;
            fuseButton();
            pcMove();
            openCards();
        }

        private void pcMove()
        {
            bool shouldARaise = false;
            bool hasEnoughMoney = true;
            if (Player.currentPlayer.LastMove.Equals(Moves.Raise) && Player.currentPlayer.LastMove.Equals(Moves.Allin))
            {
                shouldARaise = true;
                //користувач пдівищив на 50 а в комп'ютера лише 20 фішок перевірити цю ситуацію
                //hasEnoughMoney якщо пк не має достатньо грошей то він зможе піти в олл ин або паснути
                if (raiseBet > pc.Balance)
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
                pc.LastMove = DetermineMove(shouldARaise, hasEnoughMoney, move, 30, 60, 85);

            }
            else if (prob <= 40)
            {
                pc.LastMove = DetermineMove(shouldARaise, hasEnoughMoney, move, 20, 55, 90);
            }
            else
            {
                pc.LastMove = DetermineMove(shouldARaise, hasEnoughMoney, move, 5, 40, 70, 70, 15, 80);

            }
            if (pc.LastMove.Equals(Moves.Fold))
            {
                label4.Text = "Fold In";
                pictureBox9.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{pc.Cards[0].GetImgFileName()}");
                pictureBox8.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{pc.Cards[1].GetImgFileName()}");
                Player.currentPlayer.Balance += rate;

                // TODO restart game and show message box
            }
            else if (pc.LastMove.Equals(Moves.Check))
            {
                label4.Text = "Check";
            }
            else if (pc.LastMove.Equals(Moves.Raise))
            {
                label4.Text = "Raise";

                //наскільки піднімає бот докрутити 
                pc.Balance -= rate;
                Player.currentPlayer.Balance += rate;
            }
            else
            {
                label4.Text = $"Bot go to the All in bet: {pc.Balance + rate} chips";
                raiseBet = pc.Balance;
                rate += raiseBet;
                pc.Balance = 0;
            }

            //TODO add currentBet(currentRate) property to Player and make Computer player
            if (label4.Text.Contains("All in") || label4.Text.ToLower().Contains("raise"))
            {
                label3.Text = rate.ToString();
            }

            isUser = true;
            fuseButton();

        }

        private Moves DetermineMove(bool shouldARaise, bool hasEnoughMoney, int move, int foldProbability, int checkProbability, int raiseProbability, int allinIfRaise = 50, int foldIfRaise = 45, int raiseIfRaise = 95)
        {
            if (shouldARaise)
            {
                if (!hasEnoughMoney)
                {
                    if (move < allinIfRaise)
                    {
                        return Moves.Allin;
                    }
                    else
                    {
                        return Moves.Fold;
                    }
                }
                else
                {
                    if (move < foldIfRaise)
                    {
                        return Moves.Fold;
                    }
                    else if (move < raiseIfRaise)
                    {
                        return Moves.Raise;
                    }
                    else
                    {
                        return Moves.Allin;
                    }
                }
            }
            else
            {
                if (move < foldProbability)
                {
                    return Moves.Fold;
                }
                else if (move < checkProbability)
                {
                    return Moves.Check;
                }
                else if (move < raiseProbability)
                {
                    return Moves.Raise;
                }
                else
                {
                    return Moves.Allin;
                }
            }
        }
        public void openCards()
        {
            //if (!openCard)
            //{
            //    return;
            //}
            if (Player.currentPlayer.LastMove == Moves.Check && pc.LastMove == Moves.Check)
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
            else if (Player.currentPlayer.LastMove == Moves.Raise && (pc.LastMove == Moves.Raise || pc.LastMove == Moves.Allin))
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
            else if (Player.currentPlayer.LastMove == Moves.Allin && (pc.LastMove == Moves.Raise || pc.LastMove == Moves.Allin))
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
            List<Card> cards = new List<Card>(pc.Cards);
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
            List<Card> cards = new List<Card>(pc.Cards);
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
                foldButton.Enabled = true;
                checkButton.Enabled = true;
                raiseButton.Enabled = true;
                allinButton.Enabled = true;
            }
            else
            {
                foldButton.Enabled = false;
                checkButton.Enabled = false;
                raiseButton.Enabled = false;
                allinButton.Enabled = false;
            }
        }

        private void raiseButtonClick(object sender, EventArgs e)
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
            Player.currentPlayer.LastMove = Moves.Raise;
            fuseButton();
            pcMove();
            countMoves++;
            openCards();

        }

        private void allinButtonClick(object sender, EventArgs e)
        {
            //перевірка чи зможе користувач піти в олин 2 раз
            if (Player.currentPlayer.LastMove.Equals(Moves.Allin))
            {
                MessageBox.Show("You have already set everything up");
            }
            else
            {
                isUser = false;
                label5.Text = $"User go to the ALLIN bet: {Player.currentPlayer.Balance + rate} chips";
                rate += Player.currentPlayer.Balance;
                raiseBet = Player.currentPlayer.Balance;
                Player.currentPlayer.Balance = 0;
                fuseButton();
                label6.Text = Player.currentPlayer.Balance + " chips";
                label2.Text = rate.ToString();
                Player.currentPlayer.LastMove = Moves.Allin;
                pcMove();
                openCards();
            }
        }
    }
}