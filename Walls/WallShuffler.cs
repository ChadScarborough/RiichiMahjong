using RMU.Tiles;
using Godot;

namespace RMU.Walls
{
    internal static class WallShuffler
    {
        public static void Shuffle(Wall wall)
        {
            List<Tile> input = new();
            List<Tile> output = new();
            RandomNumberGenerator random = new();
            Listify(wall, input);
            Randomize(input, output, random);
            wall.PopulateWall(output);
        }

        private static void Randomize(List<Tile> input, List<Tile> output, RandomNumberGenerator random)
        {
            while (input.Count > 0)
            {
                int r = random.RandiRange(0, input.Count - 1);
                output.Add(input[r]);
                input.RemoveAt(r);
            }
        }

        private static void Listify(Wall wall, List<Tile> input)
        {
            while (wall.GetSize() > 0)
            {
                input.Add(wall.DrawTileFromWall());
            }
        }
    }
}
