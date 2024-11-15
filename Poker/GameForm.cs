
using Poker.Models;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Poker
{
    public partial class GameForm : Form
    {
        public Player pc = new Player { Nickname = "Bob", Balance = Player.currentPlayer.Balance };

        int countMoves = 0;

        static string CARD_IMG = @"D:\������\Poker\Poker\images\";

        Deck deck = new Deck();

        private bool isUser = true;

        private Card[] board = new Card[5];

        int raiseBet = 0;

        //��� ���� ��� 
        private void restart()
        {
            if (pc.Balance < 500)
            {
                pc.Balance = 500;
            }
            if(Player.currentPlayer.Balance < 5) 
            {
                MessageBox.Show("Player doesn't have enough money");
                Close();
                return;
            }
            pc.Rate = 5;
            Player.currentPlayer.Rate = 5;
            deck = new Deck();
            isUser = true;
            fuseButton();
            board = new Card[5];
            raiseBet = 0;

            CheckingCombinations combinations = new CheckingCombinations();

            deck.Shuffle();
            //������� 2 ����� ���
            Card mycard1 = deck.DrawCard();
            Card mycard2 = deck.DrawCard();

            Player.currentPlayer.Cards[0] = mycard1;
            Player.currentPlayer.Cards[1] = mycard2;

            //������� 3 ����� �� ���
            Card tablecard1 = deck.DrawCard();
            Card tablecard2 = deck.DrawCard();
            Card tablecard3 = deck.DrawCard();
            Player.currentPlayer.Balance -= 5;
            pc.Balance -= 5;
            board[0] = tablecard1;
            board[1] = tablecard2;
            board[2] = tablecard3;

            //pc cards
            Card pcCard1 = deck.DrawCard();
            Card pcCard2 = deck.DrawCard();

            pcCardPictureBox1.BackgroundImage = Image.FromFile($"{CARD_IMG}\\background.png");
            pcCardPictureBox2.BackgroundImage = Image.FromFile($"{CARD_IMG}\\background.png");

            pc.Cards[0] = pcCard1;
            pc.Cards[1] = pcCard2;


            //�������� ���� �� �����

            playerCardPictureBox2.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{mycard1.GetImgFileName()}");
            playerCardPictureBox1.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{mycard2.GetImgFileName()}");

            //�������� 3 ����� �� ���
            cardDeckPictureBox1.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{tablecard1.GetImgFileName()}");
            cardDeckPictureBox2.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{tablecard2.GetImgFileName()}");
            cardDeckPictureBox3.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{tablecard3.GetImgFileName()}");
            ratePlayerLabel.Text = "5";
            ratePcLabel.Text = "5";

            cardDeckPictureBox4.BackgroundImage = null;
            cardDeckPictureBox5.BackgroundImage = null;

            label4.Text = "";
            label5.Text = "";

            balancePlayerLabel.Text = Player.currentPlayer.Balance + " chips";
            balancePcLabel.Text = $"{pc.Balance} chips";
            bankLabel.Text = $"{Player.currentPlayer.Rate + pc.Rate}";

            pc.LastMove = Moves.Check;
            Player.currentPlayer.LastMove = Moves.Check;
        }

        public GameForm(string nickname)
        {
            InitializeComponent();

            namePlayerLabel.Text = nickname;
        }
      
        public void AddChipsToBot(int chips)
        {
            pc.Balance += chips;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CombinationForm form = new CombinationForm();
            form.ShowDialog();
        }

        private void pcMove()
        {
            bool shouldARaise = false;
            bool hasEnoughMoney = true;
            if (Player.currentPlayer.LastMove.Equals(Moves.Raise) || Player.currentPlayer.LastMove.Equals(Moves.Allin))
            {
                shouldARaise = true;
                //hasEnoughMoney ���� �� �� �� ��������� ������ �� �� ����� ��� � ��� �� ��� �������
                if (raiseBet > pc.Balance)
                {
                    hasEnoughMoney = false;
                }
            }

            int prob = probabilityOfWin();
            Random random = new Random();
            int move = random.Next(0, 100);
            int[] Points = { 5, 10, 25, 50 };

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
                pcCardPictureBox1.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{pc.Cards[0].GetImgFileName()}");
                pcCardPictureBox2.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{pc.Cards[1].GetImgFileName()}");
                Player.currentPlayer.Balance += pc.Rate;
                Player.currentPlayer.Balance += Player.currentPlayer.Rate;
            }
            else if (pc.LastMove.Equals(Moves.Check))
            {
                label4.Text = "Check";
            }
            else if (pc.LastMove.Equals(Moves.Raise))
            {
                if (Player.currentPlayer.LastMove == Moves.Check)
                {
                    int minBet = 1;
                    int maxBet = pc.Balance;
                    if (maxBet >= minBet)
                    {
                        Random randoms = new Random();
                        raiseBet = randoms.Next(minBet, maxBet + 1);
                    }
                    else
                    {
                        raiseBet = pc.Balance;
                    }
                }
                else if (Player.currentPlayer.LastMove == Moves.Raise)
                {
                    int minBet = raiseBet;
                    int maxBet = pc.Balance;
                    if(maxBet >= minBet)
                    {
                        Random randoms = new Random();
                        raiseBet = randoms.Next(minBet, maxBet + 1);
                    }
                    else
                    {
                        raiseBet = pc.Balance;
                    }
                }
                else
                {
                    MessageBox.Show("Error.");
                }
                pc.Balance -= raiseBet;
                pc.Rate += raiseBet;
                label4.Text = $"Bob raise to {pc.Rate}";


            }
            else
            {
                label4.Text = $"Bot go to the All in bet: {pc.Balance + pc.Rate} chips";
                raiseBet = pc.Balance;
                pc.Rate += raiseBet;
                pc.Balance = 0;
            }
            if (label4.Text.Contains("All in") || label4.Text.ToLower().Contains("raise"))
            {
                ratePcLabel.Text = pc.Rate.ToString();
                bankLabel.Text = $"{Player.currentPlayer.Rate + pc.Rate}";
                balancePcLabel.Text = $"{pc.Balance} chips";
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
        public async void openCards()
        {
            if (Player.currentPlayer.LastMove == Moves.Check && pc.LastMove == Moves.Check)
            {
                if (board[3] == null)
                {
                    board[3] = deck.DrawCard();
                    cardDeckPictureBox4.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[3].GetImgFileName()}");
                }
                else if (board[4] == null)
                {
                    board[4] = deck.DrawCard();
                    cardDeckPictureBox5.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[4].GetImgFileName()}");
                }
                else
                {
                    gameOver();
                }
            }
            else if (Player.currentPlayer.LastMove == Moves.Allin && pc.LastMove == Moves.Raise || 
                Player.currentPlayer.LastMove == Moves.Raise && pc.LastMove == Moves.Allin ||
                Player.currentPlayer.LastMove == Moves.Allin && pc.LastMove == Moves.Allin)
            {
                if (board[3] == null)
                {
                    board[3] = deck.DrawCard();
                    cardDeckPictureBox4.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[3].GetImgFileName()}");
                    
                }
                if (board[4] == null)
                {
                    board[4] = deck.DrawCard();
                    cardDeckPictureBox5.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[4].GetImgFileName()}");
                }

                gameOver();
            }
            else if (Player.currentPlayer.LastMove == Moves.Fold || pc.LastMove == Moves.Fold)
            {
                if (board[3] == null)
                {
                    board[3] = deck.DrawCard();
                    cardDeckPictureBox4.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[3].GetImgFileName()}");
                    
                }
                if (board[4] == null)
                {
                    board[4] = deck.DrawCard();
                    cardDeckPictureBox5.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{board[4].GetImgFileName()}");
                }
                pcCardPictureBox1.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{pc.Cards[0].GetImgFileName()}");
                pcCardPictureBox2.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{pc.Cards[1].GetImgFileName()}");
                MessageBox.Show("The End.");
                Thread.Sleep(2000);
                restart();
            }
        }

        private void gameOver()
        {
            pcCardPictureBox1.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{pc.Cards[0].GetImgFileName()}");
            pcCardPictureBox2.BackgroundImage = Image.FromFile($"{CARD_IMG}\\{pc.Cards[1].GetImgFileName()}");

            CombinationCards pcCombinations = checkCombination(pc);
            CombinationCards playerCombinations = checkCombination(Player.currentPlayer);

            if (pcCombinations > playerCombinations)
            {
                MessageBox.Show($"Bob wins the game! Bob receives: {pc.Rate + Player.currentPlayer.Rate}", "Game Over",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                pc.Balance += Player.currentPlayer.Rate + pc.Rate;

            }
            else if (pcCombinations < playerCombinations)
            {
                MessageBox.Show($"You win the game! {Player.currentPlayer.Nickname} receives {Player.currentPlayer.Rate + pc.Rate} ",
                    "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Player.currentPlayer.Balance += Player.currentPlayer.Rate + pc.Rate;
            }
            else
            {
                MessageBox.Show($"It's a draw! {Player.currentPlayer.Nickname}, {Player.currentPlayer.Rate}, Bob, {pc.Rate}",
                    "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Player.currentPlayer.Balance += Player.currentPlayer.Rate;
                pc.Balance += pc.Rate;
            }
            MessageBox.Show("The End.");
            restart();
        }
        private CombinationCards checkCombination(Player player)
        {
            CheckingCombinations combinations = new CheckingCombinations();
            //��������� ���� �� ���� 3 ����� ������ ���� , � ���� 5 ���� �� ���� ���� 
            List<Card> cards = new List<Card>(player.Cards);
            if (board[3] == null)
            {
                cards.Add(board[0]);
                cards.Add(board[1]);
                cards.Add(board[2]);

            }
            else if (board[4] == null)
            {
                cards.Add(board[0]);
                cards.Add(board[1]);
                cards.Add(board[2]);
                cards.Add(board[3]);
            }
            else
            {
                cards.AddRange(board);
            }

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
            cards.Add(board[0]);
            cards.Add(board[1]);
            cards.Add(board[2]);
            if (board[3] != null)
            {
                cards.Add(board[3]);
            }
            if (board[4] != null)
            {
                cards.Add(board[4]);
            }
           
            CombinationCards result = checkCombination(pc);

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

        #region userMoves

        private async void foldButtonClick(object sender, EventArgs e)
        {
            Player.currentPlayer.LastMove = Moves.Fold;
            isUser = false;
            fuseButton();
            pc.Balance += Player.currentPlayer.Rate + pc.Rate;
            openCards();
        }

        private void checkButtonClick(object sender, EventArgs e)
        {
            if (pc.Rate > Player.currentPlayer.Rate)
            {
                MessageBox.Show("You can`t check");
                return;
            }
            Player.currentPlayer.LastMove = Moves.Check;
            isUser = false;
            fuseButton();
            label5.Text = "User: Check";
            pcMove();
            openCards();
        }

        private void raiseButtonClick(object sender, EventArgs e)
        {
            isUser = false;
            if (Player.currentPlayer.Balance < raiseBet)
            {
                MessageBox.Show("not enough funds to bet", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isUser = true;
                return;
            }
            RaiseForm raise = new RaiseForm(pc);
            raise.ShowDialog();
            if (raise.isAccepted)
            {
                raiseBet = raise.bet;
                Player.currentPlayer.Balance -= raiseBet;
                Player.currentPlayer.Rate += raiseBet;
                label5.Text = $"User raise bet to: {Player.currentPlayer.Rate} chips";
                balancePlayerLabel.Text = Player.currentPlayer.Balance + " chips";
                ratePlayerLabel.Text = Player.currentPlayer.Rate.ToString();
                bankLabel.Text = $"{Player.currentPlayer.Rate + pc.Rate}";
                Player.currentPlayer.LastMove = Moves.Raise;
                fuseButton();
                if (pc.LastMove != Moves.Allin)
                {
                    pcMove();
                }
                countMoves++;
                openCards();
            }

        }

        private void allinButtonClick(object sender, EventArgs e)
        {
            //�������� �� ����� ���������� ��� � ���� 2 ���
            if (Player.currentPlayer.LastMove.Equals(Moves.Allin))
            {
                MessageBox.Show("You have already set everything up");
            }
            else
            {
                isUser = false;
                label5.Text = $"User go to the ALLIN bet: {Player.currentPlayer.Balance + Player.currentPlayer.Rate} chips";
                Player.currentPlayer.Rate += Player.currentPlayer.Balance;
                raiseBet = Player.currentPlayer.Balance;
                Player.currentPlayer.Balance = 0;
                fuseButton();
                balancePlayerLabel.Text = Player.currentPlayer.Balance + " chips";
                ratePlayerLabel.Text = Player.currentPlayer.Rate.ToString();
                bankLabel.Text = $"{Player.currentPlayer.Rate + pc.Rate}";
                Player.currentPlayer.LastMove = Moves.Allin;
                if (!pc.LastMove.Equals(Moves.Allin))
                {
                    pcMove();
                }
                openCards();
            }
        }
        #endregion

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serialization.updatePlayer();
        }

    }
}