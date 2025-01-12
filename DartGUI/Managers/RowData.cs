using DartGUI.Helpers;

namespace DartGUI.Managers;

internal class RowData
{
    #region Local Variables

    private readonly Border _playerIdBorder;
    private readonly Label _playerIdLabel;

    private readonly Border _playerNameBorder;
    private readonly Label _playerNameLabel;

    private readonly Border _playerLegsWonBorder;
    private readonly Label _playerLegsWonLabel;

    private readonly Border _playerPointsLeftBorder;
    private readonly Label _playerPointsLeftLabel;

    #endregion

    #region Constructors

    internal RowData(
        Border playerIdBorder, Label playerIdLabel,
        Border playerNameBorder, Label playerNameLabel,
        Border playerLegsWonBorder, Label playerLegsWonLabel,
        Border playerPointsLeftBorder, Label playerPointsLeftLabel)
    {
        _playerIdBorder = playerIdBorder;
        _playerIdLabel = playerIdLabel;
        _playerNameBorder = playerNameBorder;
        _playerNameLabel = playerNameLabel;
        _playerLegsWonBorder = playerLegsWonBorder;
        _playerLegsWonLabel = playerLegsWonLabel;
        _playerPointsLeftBorder = playerPointsLeftBorder;
        _playerPointsLeftLabel = playerPointsLeftLabel;
    }

    #endregion

    #region Operations

    internal void SetRowColor(RowStatus status)
    {
        switch (status)
        {
            case RowStatus.Default:
            {
                _playerIdBorder.Stroke = DesignColors.BORDER_COLOR;
                _playerIdLabel.TextColor = DesignColors.LABEL_TEXT_COLOR;
                _playerNameBorder.Stroke = DesignColors.BORDER_COLOR;
                _playerNameLabel.TextColor = DesignColors.LABEL_TEXT_COLOR;
                _playerLegsWonBorder.Stroke = DesignColors.BORDER_COLOR;
                _playerLegsWonLabel.TextColor = DesignColors.LABEL_TEXT_COLOR;
                _playerPointsLeftBorder.Stroke = DesignColors.BORDER_COLOR;
                _playerPointsLeftLabel.TextColor = DesignColors.LABEL_TEXT_COLOR;
                break;
            }
            case RowStatus.CurrentPlayer:
            {
                _playerIdBorder.Stroke = DesignColors.BORDER_CUSTOM_COLOR;
                _playerIdLabel.TextColor = DesignColors.LABEL_CUSTOM_TEXT_COLOR;
                _playerNameBorder.Stroke = DesignColors.BORDER_CUSTOM_COLOR;
                _playerNameLabel.TextColor = DesignColors.LABEL_CUSTOM_TEXT_COLOR;
                _playerLegsWonBorder.Stroke = DesignColors.BORDER_CUSTOM_COLOR;
                _playerLegsWonLabel.TextColor = DesignColors.LABEL_CUSTOM_TEXT_COLOR;
                _playerPointsLeftBorder.Stroke = DesignColors.BORDER_CUSTOM_COLOR;
                _playerPointsLeftLabel.TextColor = DesignColors.LABEL_CUSTOM_TEXT_COLOR;
                break;
            }
            default: // Technically, this should never go to this point
                throw new ArgumentOutOfRangeException(nameof(status), status, null);
        }
    }

    internal void SetRowData(Player player)
    {
        _playerLegsWonLabel.Text = player.LegsWon.ToString();
        _playerPointsLeftLabel.Text = player.PointsLeft.ToString();
    }

    #endregion

    #region Properties

    internal Border PlayerIdBorder => _playerIdBorder;
    internal Border PlayerNameBorder => _playerNameBorder;
    internal Border PlayerLegsWonBorder => _playerLegsWonBorder;
    internal Border PlayerPointsLeftBorder => _playerPointsLeftBorder;

    #endregion
}
