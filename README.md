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
  -***Palet.cs***;

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

```
  public Ball()
  {
      rect = new Rectangle((Globals.WIDTH - w) / 2, (Globals.HEIGHT - h) / 2, w, h);
  }
```  
- **Ball** - Esta secção está encarregue de inserir a nossa bola no centro da tela, assim como também o seu tamanho.  

```
  public void Update(GameTime gt, Palet p1, Palet p2)
  {
      int dt = (int)(gt.ElapsedGameTime.TotalSeconds * speed);

      if (rect.Y <= 0 || rect.Y >= Globals.HEIGHT - h) down *= -1;

      if (p1.rect.Intersects(rect) || p2.rect.Intersects(rect)) right *= -1;

      if(rect.X <= 0)
      {
          Globals.p2_points++;
          resetGame();
      }
      if(rect.X >= Globals.WIDTH - w)
      {
          Globals.p1_points++;
          resetGame();
      }

      rect.X += dt * right;
      rect.Y += dt * down;
  }
```
- **Update** - Esta secção trata da interação que a bola tem com o resto do jogo. Delimitando a bola para só o tela do jogo em si, assim como a interação da bola com os jogadores. Também é responsável pela atualização da pontuação dos jogadores quando a bola chega a uma das bordas laterais do ecrã.  

```
  void resetGame()
  {
     rect.X = (Globals.WIDTH - w) / 2;
     rect.Y = (Globals.HEIGHT - h) / 2;
  }
```
- **RestGame** - Aqui temos a função ***resetGame()*** que, como o nome nos diz, reseta o jogo para começar a nova rodada, posicionando a nossa bola devolta no centro da tela.

```
  public void Draw()
  {
      Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
  }
```
Isto serve para dar a nossa bola uma forma para os jogadores poderem visualiza-la enquanto jogam.

### Palet.cs

  Esta classe é responsável pela criação e controlo das paletes para ambos jogadores. 

```
  bool isSecondPlayer;
  int w = 40;
  int h = 300;
  float speed = 700f;

  public Rectangle rect;
```
