# Pong

Francisco Pinheiro Ribeiro a27942  
José Miguel Cunha a22550

---

## Introdução

  Iremos apresentar o código da recriação de um jogo clássico na história de videojogos, Pong. Nesta apresentação iremos demonstrar o código utilizado pelo utilizador, como funciona e até o problema com o jogo do momento.  
  Para verem o código original podem clicar [aqui](https://github.com/papnotag/MonogamePong.git).  

  O nosso utilizador dividiu o seu código em 3 classes mais a classe *Game1.cs* em si. Estas classes sendo:  
  -***Globals.cs***;  
  -***Ball.cs***;  
  -***Palet.cs***;

---

### Globals.cs

  Esta classe é responsável por todas as variáveis globais que serão utilizadas no código para executar o jogo. Coisas como a dimnensão da tela do jogador, a cor do background e também a pontuação inicial dos jogadores.

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

  Esta classe é responsável por controlar bola que os jogadores vão atirar entre si. 

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
- **Ball** - Esta secção está encarregue de inserir a bola no centro da tela, assim como definir também o seu tamanho.  

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
- **ResetGame** - Aqui temos a função ***resetGame()*** que, como o nome nos diz, reseta o jogo para começar a nova ronda, posicionando a bola de volta no centro da tela.

```
  public void Draw()
  {
      Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
  }
```
A função Draw serve para dar a nossa bola uma forma física no ecrã para que os jogadores possam visualiza-la enquanto jogam.

### Palet.cs

  Esta classe é responsável pela criação e controlo das paletes movíveis para ambos jogadores. 

```
  bool isSecondPlayer;
  int w = 40;
  int h = 300;
  float speed = 700f;

  public Rectangle rect;
```
  As variáveis globais que serão utilizados para a nossa classe *Palet*.

```
  public Palet(bool sp)
  {
     isSecondPlayer = sp;
     rect = new Rectangle(sp ? Globals.WIDTH - w : 0, (Globals.HEIGHT - h) / 2, w, h);
  }
```
- **Palet** - Trata da criação da palete dos jogadores, posicionando-as nos extremos laterais do ecrã.

```
  public void Update(GameTime gt)
  {
     int dt = (int)(gt.ElapsedGameTime.TotalSeconds * speed);
     KeyboardState kstate = Keyboard.GetState();

     if((isSecondPlayer ? kstate.IsKeyDown(Keys.Up) : kstate.IsKeyDown(Keys.W)) && rect.Y > 0)
     {
         rect.Y -= dt;
     }
     if((isSecondPlayer ? kstate.IsKeyDown(Keys.Down) : kstate.IsKeyDown(Keys.S)) && rect.Y < Globals.HEIGHT-h)
     {
         rect.Y += dt;
     }
  }
```
- **Update** - Está encarregue da atualização do movimento das paletes dos jogadores quando estes usam as teclas W e S, e as setas Cima e Baixo.

```
  public void Draw()
  {
      Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
  }
```
- **Draw** - Dá aos jogadores uma representação visual das paletes.

---
## Game1.cs

  Com a maior parte dos aspetos tratados nas classes mencionadas anteriormente, a classe *Game1.cs* está em carregue de organizar tudo de forma a que o jogo possa ser executado. 

```
  private GraphicsDeviceManager _graphics;
  Palet p1;
  Palet p2;
  Ball ball;
```
  Preparar os vários componentes que necessitamos para preparar o jogo. Os jogadores, a bola e o ecrã de jogo usada para jogar.

```
  public Game1()
  {
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = false;
      _graphics.PreferredBackBufferWidth = Globals.WIDTH;
      _graphics.PreferredBackBufferHeight = Globals.HEIGHT;
      _graphics.IsFullScreen = Globals.isFullScreen;
  }
```
- **Game1** - Está encarregue de preparar a tela de jogo, removendo o rato do ecrã assim como delimitando a tela para o tamanho do ecrã e removendo as bordas de forma a que o jogo seja *fullscreen*.

```
  protected override void Initialize()
  {
      p1 = new Palet(false);
      p2 = new Palet(true);
      ball = new Ball();
      base.Initialize();
  }
```
- **Initialize** - Inicializa os dois jogadores assim como também a bola que será usada para jogar.

```
  protected override void LoadContent()
  {
      Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
      Globals.pixel = new Texture2D(GraphicsDevice, 1, 1);
      Globals.pixel.SetData<Color>(new Color[] { Color.White });
  }
```
- **LoadContent** - Carrega tudo que precisamos para podermos executar corretamente o conteudo do jogo.

```
  protected override void Update(GameTime gameTime)
  {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
          Exit();

      p1.Update(gameTime);
      p2.Update(gameTime);
      ball.Update(gameTime, p1, p2);

      base.Update(gameTime);
  }
```
- **Update** - Está encarregue de atualizar o jogo de forma a que os jogadores e a bola se possam mexer. Também é aqui definido como os jogadores podem sair do jogo.

```
  protected override void Draw(GameTime gameTime)
  {
      GraphicsDevice.Clear(Globals.BACKGROUND_COLOR);

      Globals.spriteBatch.Begin();

      p1.Draw();
      p2.Draw();
      ball.Draw();

      Globals.spriteBatch.End();

      base.Draw(gameTime);
  }
```
- **Draw** - Está encarregue de desenhar e apresentar aos jogadores, visualmente, o que se passa durante a execução do jogo. Redesenhando os componentes a cada novo segundo de jogo.

---

### Conclusão

  Um problema encontramos quando analisamos o código é que não foi escrito nenhuma função ou classe que de facto mostre aos jogadores a pontuação de cada um enquanto o jogo decorre, apesar de existirem e serem incializadas as variáveis para guardar e atualizar todas as vezes que um jogador marca um ponto. No entanto, fora disso, o jogo é relativamente simples, em termos de jogabilidade e em termos de complexidade de código.








