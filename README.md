# Pong

Francisco Pinheiro Ribeiro a27942  
José Miguel Cunha a22550

---

## Introdução

  Iremos apresentar o código da recriação de um jogo clássico na história de videojogos, Pong. Nesta apresentação iremos demonstrar o código utilizado pelo utilizador, como funciona e até o problema com o jogo do momento.  
  Para verem o código original podem clicar [aqui](https://github.com/papnotag/MonogamePong.git).  

  O nosso utilizador dividiu o seu código em 3 classes mais o *Game1.cs* em si. Esta classes sendo:  
  -***Globals.cs***;  
  -***Ball.cs***;  
  -***Pallet.cs***;

---

### Globals.cs

  Esta classe é responsável por todas as variáveis globais que serão utilizadas no código para rodar o jogo. Coisas como a tela do jogador, a cor do background, algumas classes que tratam da apresentação visual do jogo e também a pontuação do jogadores.

```C#  

internal class Globals  
{  
  public static int WIDTH = 1920;  
  public static int HEIGHT = 1080;  
  public static bool isFullScreen = true;  
  public static Color BACKGROUND_COLOR = Color.Black;  

  public static SpriteBatch spriteBatch;  

  public static Texture2D pixel;  

  public static int p1_points = 0;  
  public static int p2_points = 0;  
}  

```

### Ball.cs

  Esta classe é responsável pela bola à qual os jogadores vão atirar entre si. 

```
  int w = 30;
  int h = 30;
  Rectangle rect;
  float speed = 1000f;

  int right = 1;
  int down = 1;
```
 Ela vem com algumas variáveis que nos vão ajudar no código em relação ao tamanho, posicionamento e movimento da nossa bola.  


