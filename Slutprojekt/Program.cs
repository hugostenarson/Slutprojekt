using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Raylib_cs;



Raylib.InitWindow(800, 600, "Catch the Fruits!");
Raylib.SetTargetFPS(60);

Random generator = new Random();
int xPos = generator.Next(20, 780);
int score = 0;

Texture2D fruitBasket = Raylib.LoadTexture("fruitbasket.png");
Texture2D banana = Raylib.LoadTexture("banana.png");
Raylib_cs.Rectangle barrierL = new Raylib_cs.Rectangle(-1, 0, 1, 600);
Raylib_cs.Rectangle barrierR = new Raylib_cs.Rectangle(795, 0, 1, 600);
Raylib_cs.Rectangle barrierBot = new Raylib_cs.Rectangle(0, 600, 800, 1);
Raylib_cs.Rectangle basketRect = new Raylib_cs.Rectangle(360, 565, 40, 20);
Raylib_cs.Rectangle bananaRect = new Raylib_cs.Rectangle(xPos, 10, 10, 5);


Vector2 fall = new Vector2(0, 3);


Vector2 move = new Vector2(4,0);



while (!Raylib.WindowShouldClose())
{


/* Spawnar en ny banan när en annan fångas */
if (Raylib.CheckCollisionRecs(basketRect, bananaRect))
{
    bananaRect.y = -20;
    bananaRect.x = generator.Next(20, 780);
    score += 1;
    
    
}



/* Stoppar korgen från att åka ur bild */
if (Raylib.CheckCollisionRecs(basketRect, barrierL))
{
    basketRect.x = -1;
}

if (Raylib.CheckCollisionRecs(basketRect, barrierR))
{
    basketRect.x = 740;
}

if (Raylib.CheckCollisionRecs(bananaRect, barrierBot))
{
    bananaRect.y = -20;
    bananaRect.x = generator.Next(20, 780);
}


move = Vector2.Zero;
if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
{
    move.X = -6;
}

if(Raylib.IsKeyDown(KeyboardKey.KEY_D))
{
    move.X = 6;
}




basketRect.x += move.X;


bananaRect.y += fall.Y;


Raylib.BeginDrawing();
    Raylib.ClearBackground(Raylib_cs.Color.LIGHTGRAY);
    Raylib.DrawRectangleRec(barrierL, Raylib_cs.Color.LIGHTGRAY);
    Raylib.DrawRectangleRec(barrierR, Raylib_cs.Color.LIGHTGRAY);
    Raylib.DrawRectangleRec(barrierBot, Raylib_cs.Color.BLACK);
    Raylib.DrawTexture(banana, (int)bananaRect.x, (int)bananaRect.y, Raylib_cs.Color.WHITE);
    Raylib.DrawTexture(fruitBasket, (int)basketRect.x, (int)basketRect.y, Raylib_cs.Color.WHITE);
    Raylib.DrawText("SCORE: " + score, 20, 40, 30, Raylib_cs.Color.GREEN);
Raylib.EndDrawing();
}