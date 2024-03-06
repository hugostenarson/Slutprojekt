using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Catch the Fruits!");
Raylib.SetTargetFPS(60);

Texture2D fruitBasket = Raylib.LoadTexture("fruitbasket.png");
Raylib_cs.Rectangle basketRect = new Raylib_cs.Rectangle(360, 565, 40, 20);
Raylib_cs.Rectangle barrierL = new Raylib_cs.Rectangle(-1, 0, 1, 600);
Raylib_cs.Rectangle barrierR = new Raylib_cs.Rectangle(780, 0, 2, 600);

Vector2 move = new Vector2(4,0);
float speed = 5;



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



if (move.Length() > 0)
    {
        move = Vector2.Normalize(move) * speed;
    }
basketRect.x += move.X;




Raylib.BeginDrawing();
    Raylib.ClearBackground(Raylib_cs.Color.LIGHTGRAY);
    Raylib.DrawTexture(fruitBasket, (int)basketRect.x, (int)basketRect.y, Raylib_cs.Color.WHITE);
    Raylib.DrawRectangleRec(barrierL, Raylib_cs.Color.BLACK);
    Raylib.DrawRectangleRec(barrierR, Raylib_cs.Color.BLACK);
Raylib.EndDrawing();
}