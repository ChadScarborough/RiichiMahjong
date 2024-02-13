using Godot;
using RMU.Tiles;
using System;

namespace RMU.Players
{
    public abstract partial class Player
    {
        public event EventHandler OnHandChanged;
        public event EventHandler OnShantenUpdated;

        public void Discard(int index)
        {
            if (_isInRiichi)
                return;
            if (!IsActivePlayer()) return;
            if (_isPreRiichi)
            {
                bool isValidRiichiTile = false;
                foreach (Tile t in _riichiTiles)
                {
                    if (AreTilesEquivalent(t, _hand.GetClosedTiles()[index]))
                    {
                        isValidRiichiTile = true;
                        break;
                    }
                }
                if (isValidRiichiTile == false)
                    return;
                _isPreRiichi = false;
                _isInRiichi = true;
                GD.Print("Riichi value set properly");
            }
            NegateCalls();
            Tile tile = _hand.GetClosedTiles()[index].Clone();
            _hand.DiscardTile(index);
            _game.SetLastTile(tile);
            _game.CheckCalls();
            _game.DecrementFirstGoAroundCounter();

            OnHandChanged?.Invoke(this, EventArgs.Empty);
            OnShantenUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void DiscardDrawTile()
        {
            if (!IsActivePlayer()) return;
            if (_isPreRiichi)
            {
                bool isValidRiichiTile = false;
                foreach (Tile t in _riichiTiles)
                {
                    if (AreTilesEquivalent(t, _hand.GetDrawTile()))
                    {
                        isValidRiichiTile = true;
                        break;
                    }
                }
                if (isValidRiichiTile == false)
                    return;
                _isPreRiichi = false;
                _isInRiichi = true;
                GD.Print("Riichi value set properly");
            }
            NegateCalls();
            Tile tile = _hand.GetDrawTile().Clone();
            _hand.DiscardDrawTile();
            _game.SetLastTile(tile);
            _game.CheckCalls();
            _game.DecrementFirstGoAroundCounter();
            OnHandChanged?.Invoke(this, EventArgs.Empty);
            OnShantenUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void DrawTile()
        {
            // if (_game.GetWall().GetSize() == 0)
            // {
            //     _game.ExhaustiveDraw();
            //     return;
            // }
            _hand.DrawTileFromWall();
            HandleAfterDrawingTile();
        }

        public void DrawTileFromDeadWall()
        {
            _hand.DrawTileFromDeadWall();
            HandleAfterDrawingTile();
        }

        private void HandleAfterDrawingTile()
        {
            CheckForTsumo();
            CheckForClosedKan();
            CheckForOpenKan2();
            CheckForRiichi();
            OnHandChanged?.Invoke(this, EventArgs.Empty);
            OnShantenUpdated?.Invoke(this, EventArgs.Empty);
            if (!IsActivePlayer())
                _game.SetActivePlayerAfterCall(this);
        }
    }
}
