A C# library to handle all the rules and mechanics of playing Riichi Mahjong, developed primarily for my ongoing project with Same Person Games: "Redshift Mahjong". 

Actions handled by this library include but are not limited to:
- Creating a new game
- Creating a specified number of players for that game
- Dealing tiles to the players
- Players drawing a new tile from the wall
- Players discarding a tile of their choosing from their hand
- Players making various calls, such as Pon, Chii, Kan, Riichi, Tsumo, and Ron
- Calculating _shanten_ (distance from _tenpai_)
- Scoring winning hands based on which _yaku_ are satisfied

While this library was built specifically for use with our ongoing Godot project, it is available for use to anyone who wishes to use it--no permission needed! 
(Note: If you plan to use this library outside of Godot, remove the GodotSharp project reference. This will require you to use a different random number generator in the Walls.WallShuffler.cs file.)
