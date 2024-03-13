using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Raylib_cs;

//Fixa så att bananer försvinner och nya spawnas när de nuddar korgen

Raylib.InitWindow(800, 600, "Catch the Fruits!");
Raylib.SetTargetFPS(60);

Random generator = new Random();
int xPos = generator.Next(20, 780);

Texture2D fruitBasket = Raylib.LoadTexture("fruitbasket.png");
Texture2D banana = Raylib.LoadTexture("banana.png");
Raylib_cs.Rectangle basketRect = new Raylib_cs.Rectangle(360, 565, 40, 20);
Raylib_cs.Rectangle bananaRect = new Raylib_cs.Rectangle(xPos, 10, 1, 1);
Raylib_cs.Rectangle barrierL = new Raylib_cs.Rectangle(-1, 0, 1, 600);
Raylib_cs.Rectangle barrierR = new Raylib_cs.Rectangle(795, 0, 1, 600);

Vector2 fall = new Vector2(0, 3);

Vector2 move = new Vector2(4,0);




while (!Raylib.WindowShouldClose())
{

if (Raylib.CheckCollisionRecs(basketRect, barrierL))
{
    basketRect.x = -1;
}

if (Raylib.CheckCollisionRecs(basketRect, barrierR))
{
    basketRect.x = 740;
}

move = Vector2.Zero;
if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
{
    move.X = -4;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_D))
{
    move.X = 4;
}




basketRect.x += move.X;


bananaRect.y += fall.Y;

Raylib.BeginDrawing();
    Raylib.ClearBackground(Raylib_cs.Color.LIGHTGRAY);
    Raylib.DrawTexture(banana, (int)bananaRect.x, (int)bananaRect.y, Raylib_cs.Color.WHITE);
    Raylib.DrawTexture(fruitBasket, (int)basketRect.x, (int)basketRect.y, Raylib_cs.Color.WHITE);
    Raylib.DrawRectangleRec(barrierL, Raylib_cs.Color.LIGHTGRAY);
    Raylib.DrawRectangleRec(barrierR, Raylib_cs.Color.BLACK);
Raylib.EndDrawing();
}