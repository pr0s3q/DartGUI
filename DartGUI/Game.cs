using System.Collections.ObjectModel;
using DartGUI.Enums;

namespace DartGUI
{
    internal class Game
    {

        #region Local Variables

        private Label? _currentDataLabel;

        private readonly List<Player> _players;

        private readonly TableManager _tableManager;

        private readonly int[] _pointsList = {0, 0, 0};

        private int _currentPlayer;

        private int _startingPlayer;

        private readonly ReadOnlyDictionary<int, Checkout> _checkoutDict = new Dictionary<int, Checkout>
        {
            { 2, new Checkout( 1, "|||   D1   |||") },
            { 3, new Checkout( 2, "|||   S1 | D1   ||| ") },
            { 4, new Checkout( 1, "|||   D2   ||| ") },
            { 5, new Checkout( 2, "|||   S1 | D2   ||| ") },
            { 6, new Checkout( 1, "|||   D3   ||| ") },
            { 7, new Checkout( 2, "|||   S3 | D2   ||| ") },
            { 8, new Checkout( 1, "|||   D4   ||| ") },
            { 9, new Checkout( 2, "|||   S1 | D4   ||| ") },
            { 10, new Checkout( 1, "|||   D5   ||| ") },
            { 11, new Checkout( 2, "|||   S3 | D4   ||| ") },
            { 12, new Checkout( 1, "|||   D6   ||| ") },
            { 13, new Checkout( 2, "|||   S5 | D4   ||| ") },
            { 14, new Checkout( 1, "|||   D7   ||| ") },
            { 15, new Checkout( 2, "|||   S7 | D4   ||| ") },
            { 16, new Checkout( 1, "|||   D8   ||| ") },
            { 17, new Checkout( 2, "|||   S1 | D8   ||| ") },
            { 18, new Checkout( 1, "|||   D9   ||| ") },
            { 19, new Checkout( 2, "|||   S3 | D8   ||| ") },
            { 20, new Checkout( 1, "|||   D10   ||| ") },
            { 21, new Checkout( 2, "|||   S5 | D8   ||| ") },
            { 22, new Checkout( 1, "|||   D11   ||| ") },
            { 23, new Checkout( 2, "|||   S7 | D8   ||| ") },
            { 24, new Checkout( 1, "|||   D12   ||| ") },
            { 25, new Checkout( 2, "|||   S9 | D8   ||| ") },
            { 26, new Checkout( 1, "|||   D13   ||| ") },
            { 27, new Checkout( 2, "|||   S11 | D8   ||| ") },
            { 28, new Checkout( 1, "|||   D14   ||| ") },
            { 29, new Checkout( 2, "|||   S13 | D8   ||| ") },
            { 30, new Checkout( 1, "|||   D15   ||| ") },
            { 31, new Checkout( 2, "|||   S15 | D8   ||| ") },
            { 32, new Checkout( 1, "|||   D16   ||| ") },
            { 33, new Checkout( 2, "|||   S17 | D8   ||| ") },
            { 34, new Checkout( 1, "|||   D17   ||| ") },
            { 35, new Checkout( 2, "|||   S3 | D16   ||| ") },
            { 36, new Checkout( 1, "|||   D18   ||| ") },
            { 37, new Checkout( 2, "|||   S5 | D16   ||| ") },
            { 38, new Checkout( 1, "|||   D19   ||| ") },
            { 39, new Checkout( 2, "|||   S7 | D16   ||| ") },
            { 40, new Checkout( 1, "|||   D20   ||| ") },
            { 41, new Checkout( 2, "|||   S9 | D16   ||| ") },
            { 42, new Checkout( 2, "|||   S10 | D16   ||| ") },
            { 43, new Checkout( 2, "|||   S11 | D16   ||| ") },
            { 44, new Checkout( 2, "|||   S12 | D16   ||| ") },
            { 45, new Checkout( 2, "|||   S13 | D16   ||| ") },
            { 46, new Checkout( 2, "|||   S6 | D20   ||| ") },
            { 47, new Checkout( 2, "|||   S15 | D16   ||| ") },
            { 48, new Checkout( 2, "|||   S16 | D16   ||| ") },
            { 49, new Checkout( 2, "|||   S17 | D16   ||| ") },
            { 50, new Checkout( 1, "|||   BULL   ||| ") },
            { 51, new Checkout( 2, "|||   S19 | D16   ||| ") },
            { 52, new Checkout( 2, "|||   S20 | D16   ||| ") },
            { 53, new Checkout( 2, "|||   S13 | D20   ||| ") },
            { 54, new Checkout( 2, "|||   S14 | D20   ||| ") },
            { 55, new Checkout( 2, "|||   S15 | D20   ||| ") },
            { 56, new Checkout( 2, "|||   S16 | D20   ||| ") },
            { 57, new Checkout( 2, "|||   S17 | D20   ||| ") },
            { 58, new Checkout( 2, "|||   S18 | D20   ||| ") },
            { 59, new Checkout( 2, "|||   S19 | D20   ||| ") },
            { 60, new Checkout( 2, "|||   S20 | D20   ||| ") },
            { 61, new Checkout( 2, "|||   T15 | D8   ||| ") },
            { 62, new Checkout( 2, "|||   T10 | D16   ||| ") },
            { 63, new Checkout( 2, "|||   T13 | D12   ||| ") },
            { 64, new Checkout( 2, "|||   T16 | D8   ||| ") },
            { 65, new Checkout( 2, "|||   T15 | D10   ||| ") },
            { 66, new Checkout( 2, "|||   T14 | D12   ||| ") },
            { 67, new Checkout( 2, "|||   T17 | D8   ||| ") },
            { 68, new Checkout( 2, "|||   T20 | D4   ||| ") },
            { 69, new Checkout( 2, "|||   T19 | D6   ||| ") },
            { 70, new Checkout( 2, "|||   T18 | D8   ||| ") },
            { 71, new Checkout( 2, "|||   T13 | D16   ||| ") },
            { 72, new Checkout( 2, "|||   T16 | D12   ||| ") },
            { 73, new Checkout( 2, "|||   T19 | D8   ||| ") },
            { 74, new Checkout( 2, "|||   T14 | D16   ||| ") },
            { 75, new Checkout( 2, "|||   T17 | D12   ||| ") },
            { 76, new Checkout( 2, "|||   T20 | D8   ||| ") },
            { 77, new Checkout( 2, "|||   T19 | D10   ||| ") },
            { 78, new Checkout( 2, "|||   T18 | D12   ||| ") },
            { 79, new Checkout( 2, "|||   T13 | D20   ||| ") },
            { 80, new Checkout( 2, "|||   T16 | D16   ||| ") },
            { 81, new Checkout( 2, "|||   T19 | D12   ||| ") },
            { 82, new Checkout( 2, "|||   T14 | D20   ||| ") },
            { 83, new Checkout( 2, "|||   T17 | D16   ||| ") },
            { 84, new Checkout( 2, "|||   T20 | D12   ||| ") },
            { 85, new Checkout( 2, "|||   T15 | D20   ||| ") },
            { 86, new Checkout( 2, "|||   T18 | D16   ||| ") },
            { 87, new Checkout( 2, "|||   T17 | D18   ||| ") },
            { 88, new Checkout( 2, "|||   T16 | D20   ||| ") },
            { 89, new Checkout( 2, "|||   T19 | D16   ||| ") },
            { 90, new Checkout( 2, "|||   T18 | D18   ||| ") },
            { 91, new Checkout( 2, "|||   T17 | D20   ||| ") },
            { 92, new Checkout( 2, "|||   T20 | D16   ||| ") },
            { 93, new Checkout( 2, "|||   T19 | D18   ||| ") },
            { 94, new Checkout( 2, "|||   T18 | D20   ||| ") },
            { 95, new Checkout( 2, "|||   T19 | D19   ||| ") },
            { 96, new Checkout( 2, "|||   T20 | D18   ||| ") },
            { 97, new Checkout( 2, "|||   T19 | D20   ||| ") },
            { 98, new Checkout( 2, "|||   T20 | D19   ||| ") },
            { 99, new Checkout( 3, "|||   T19 | S10 | D16   ||| ") },
            { 100, new Checkout( 2, "|||   T20 | D20   ||| ") },
            { 101, new Checkout( 2, "|||   T17 | BULL   ||| ") },
            { 102, new Checkout( 3, "|||   T20 | S10 | D16   ||| ") },
            { 103, new Checkout( 3, "|||   T19 | S6 | D20   ||| ") },
            { 104, new Checkout( 2, "|||   T18 | BULL   ||| ") },
            { 105, new Checkout( 3, "|||   T19 | S16 | D16   ||| ") },
            { 106, new Checkout( 3, "|||   T20 | S6 | D20   ||| ") },
            { 107, new Checkout( 2, "|||   T19 | BULL   ||| ") },
            { 108, new Checkout( 3, "|||   T19 | S19 | D16   ||| ") },
            { 109, new Checkout( 3, "|||   T19 | S12 | D8   ||| ") },
            { 110, new Checkout( 2, "|||   T20 | BULL   ||| ") },
            { 111, new Checkout( 3, "|||   T19 | S14 | D20   ||| ") },
            { 112, new Checkout( 3, "|||   T20 | S20 | D16   ||| ") },
            { 113, new Checkout( 3, "|||   T19 | S16 | D20   ||| ") },
            { 114, new Checkout( 3, "|||   T20 | S14 | D20   ||| ") },
            { 115, new Checkout( 3, "|||   T19 | S18 | D20   ||| ") },
            { 116, new Checkout( 3, "|||   T20 | S16 | D20   ||| ") },
            { 117, new Checkout( 3, "|||   T20 | S17 | D20   ||| ") },
            { 118, new Checkout( 3, "|||   T18 | T16 | D8   ||| ") },
            { 119, new Checkout( 3, "|||   T19 | T10 | D16   ||| ") },
            { 120, new Checkout( 3, "|||   T20 | S20 | D20   ||| ") },
            { 121, new Checkout( 3, "|||   T17 | T18 | D8   ||| ") },
            { 122, new Checkout( 3, "|||   T18 | T20 | D4   ||| ") },
            { 123, new Checkout( 3, "|||   T19 | T14 | D12   ||| ") },
            { 124, new Checkout( 3, "|||   T20 | T16 | D8   ||| ") },
            { 125, new Checkout( 3, "|||   T18 | T13 | D16   ||| ") },
            { 126, new Checkout( 3, "|||   T19 | S19 | BULL   ||| ") },
            { 127, new Checkout( 3, "|||   T20 | T17 | D8   ||| ") },
            { 128, new Checkout( 3, "|||   T18 | T14 | D16   ||| ") },
            { 129, new Checkout( 3, "|||   T19 | T16 | D12   ||| ") },
            { 130, new Checkout( 3, "|||   T20 | T18 | D8   ||| ") },
            { 131, new Checkout( 3, "|||   T20 | T13 | D16   ||| ") },
            { 132, new Checkout( 3, "|||   T20 | T16 | D12   ||| ") },
            { 133, new Checkout( 3, "|||   T20 | T19 | D8   ||| ") },
            { 134, new Checkout( 3, "|||   T20 | T14 | D16   ||| ") },
            { 135, new Checkout( 3, "|||   T20 | T17 | D12   ||| ") },
            { 136, new Checkout( 3, "|||   T20 | T20 | D8   ||| ") },
            { 137, new Checkout( 3, "|||   T19 | T16 | D16   ||| ") },
            { 138, new Checkout( 3, "|||   T20 | T18 | D12   ||| ") },
            { 139, new Checkout( 3, "|||   T20 | T13 | D20   ||| ") },
            { 140, new Checkout( 3, "|||   T20 | T16 | D16   ||| ") },
            { 141, new Checkout( 3, "|||   T20 | T19 | D12   ||| ") },
            { 142, new Checkout( 3, "|||   T20 | T14 | D20   ||| ") },
            { 143, new Checkout( 3, "|||   T20 | T17 | D16   ||| ") },
            { 144, new Checkout( 3, "|||   T20 | T20 | D12   ||| ") },
            { 145, new Checkout( 3, "|||   T20 | T15 | D20   ||| ") },
            { 146, new Checkout( 3, "|||   T20 | T18 | D16   ||| ") },
            { 147, new Checkout( 3, "|||   T20 | T17 | D18   ||| ") },
            { 148, new Checkout( 3, "|||   T20 | T16 | D20   ||| ") },
            { 149, new Checkout( 3, "|||   T20 | T19 | D16   ||| ") },
            { 150, new Checkout( 3, "|||   T20 | T18 | D18   ||| ") },
            { 151, new Checkout( 3, "|||   T20 | T17 | D20   ||| ") },
            { 152, new Checkout( 3, "|||   T20 | T20 | D16   ||| ") },
            { 153, new Checkout( 3, "|||   T20 | T19 | D18   ||| ") },
            { 154, new Checkout( 3, "|||   T20 | T18 | D20   ||| ") },
            { 155, new Checkout( 3, "|||   T20 | T15 | BULL   ||| ") },
            { 156, new Checkout( 3, "|||   T20 | T20 | D18   ||| ") },
            { 157, new Checkout( 3, "|||   T20 | T19 | D20   ||| ") },
            { 158, new Checkout( 3, "|||   T20 | T16 | BULL   ||| ") },
            { 160, new Checkout( 3, "|||   T20 | T20 | D20   ||| ") },
            { 161, new Checkout( 3, "|||   T20 | T17 | BULL   ||| ") },
            { 164, new Checkout( 3, "|||   T20 | T18 | BULL   ||| ") },
            { 167, new Checkout( 3, "|||   T20 | T19 | BULL   ||| ") },
            { 170, new Checkout( 3, "|||   T20 | T20 | BULL   ||| ") }
        }.AsReadOnly();

        #endregion

        #region Constructor

        internal Game(List<string> playerNames)
        {
            _players = new List<Player>(playerNames.Count);
            foreach (var name in playerNames)
            {
                _players.Add(new Player(name));
            }
            _tableManager = new TableManager(playerNames.Count);
        }

        #endregion

        #region Operations

        internal void AddCurrentDataLabel(Label currentDataLabel) => this._currentDataLabel = currentDataLabel;

        internal void AddPoints(Dartboard points)
        {
            int value = -1;
            foreach (var dict in MainCounterPage.ROW_BUTTONS_DATA)
            {
                if (dict.TryGetValue(points, out value))
                    break;
            }

            if (value == -1)
                return;

            if (!_players[_currentPlayer].TrySubtractPoints(value))
            {
                _players[_currentPlayer].AddPointsBack(CalculatePointsFromList());
                ShotsLeft = 0;
            }
            else
                _pointsList[3 - ShotsLeft] = value;

            bool nextLeg = false;
            if (_players[_currentPlayer].PointsLeft == 0)
            {
                _players[_currentPlayer].AddWonLeg();
                NextLeg();
                nextLeg = true;
            }

            UpdateTable();

            if (ShotsLeft > 1)
            {
                ShotsLeft--;
                UpdateCurrentDataLabel();
                return;
            }

            ShotsLeft = 3;
            if(!nextLeg)
            {
                if (_players.Count - 1 == _currentPlayer)
                    _currentPlayer = 0;
                else
                    _currentPlayer++;
            }

            UpdateCurrentDataLabel();
            CleanPointsList();
            SetTableRowsColor(_currentPlayer);
        }

        internal void AddRowData(
            Border playerIdBorder, Label playerIdLabel,
            Border playerNameBorder, Label playerNameLabel,
            Border playerLegsWonBorder, Label playerLegsWonLabel,
            Border playerPointsLeftBorder, Label playerPointsLeftLabel)
        {
            _tableManager.AddRow(
                playerIdBorder, playerIdLabel,
                playerNameBorder, playerNameLabel,
                playerLegsWonBorder, playerLegsWonLabel,
                playerPointsLeftBorder, playerPointsLeftLabel);
        }

        private int CalculatePointsFromList()
        {
            int result = _pointsList.Sum();

            CleanPointsList();
            return result;
        }

        private void CleanPointsList()
        {
            for (int i = 0; i < 3; i++)
                _pointsList[i] = 0;
        }

        private void CalculatePossibleCheckout(out string checkoutString)
        {
            if (_players[_currentPlayer].PointsLeft > 170 || !_checkoutDict.TryGetValue(_players[_currentPlayer].PointsLeft, out Checkout? checkout) || checkout.ShootsNeed > ShotsLeft)
            {
                checkoutString = "No possible checkouts";
                return;
            }
            
            checkoutString = checkout.Ending;
        }

        internal int GetPlayerLegsWon(int playerIndex) => _players[playerIndex].LegsWon;

        internal string GetPlayerName(int playerIndex) => _players[playerIndex].Name;

        internal int GetPlayerPointsLeft(int playerIndex) => _players[playerIndex].PointsLeft;

        internal void NextLeg()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].ResetPoints();
                _tableManager.Update(i, _players[i]);
            }

            if (_startingPlayer == _players.Count - 1)
                _startingPlayer = 0;
            else
                _startingPlayer++;

            _currentPlayer = _startingPlayer;
            ShotsLeft = 0;
        }

        internal void SetTableRowsColor(int playerIndex) => _tableManager.SetColor(playerIndex);

        private void UpdateCurrentDataLabel()
        {
            CalculatePossibleCheckout(out string checkout);
            var input = $"Possible checkout: {checkout} - Shots left: {ShotsLeft}";
            _currentDataLabel!.Text = input;
        }

        private void UpdateTable()
        {
            if (_currentPlayer == -1)
                return;
            _tableManager.Update(_currentPlayer, _players[_currentPlayer]);
        }

        #endregion

        #region Properties

        internal int ShotsLeft { get; private set; } = 3;

        #endregion

    }
}
