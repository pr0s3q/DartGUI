using DartGUI.Helpers;

namespace DartGUI.Managers
{
    internal class TableManager
    {
        #region Local Variables

        private readonly List<RowData> _rows;

        #endregion

        #region Constructors

        internal TableManager(int noOfRows)
        {
            _rows = new List<RowData>(noOfRows);
        }

        #endregion

        #region Operations

        internal void AddRow(
            Border playerIdBorder, Label playerIdLabel,
            Border playerNameBorder, Label playerNameLabel,
            Border playerLegsWonBorder, Label playerLegsWonLabel,
            Border playerPointsLeftBorder, Label playerPointsLeftLabel)
        {
            _rows.Add(new RowData(
                playerIdBorder, playerIdLabel,
                playerNameBorder, playerNameLabel,
                playerLegsWonBorder, playerLegsWonLabel,
                playerPointsLeftBorder, playerPointsLeftLabel));
        }

        internal List<RowData> GetAllRowDatas() => _rows;

        internal void Update(int playerNumber, Player player) => _rows[playerNumber].SetRowData(player);

        internal void SetColor(int playerIndex)
        {
            for (int i = 0; i < _rows.Count; i++)
                _rows[i].SetRowColor(i == playerIndex ? RowStatus.CurrentPlayer : RowStatus.Default);
        }

        #endregion
    }
}
