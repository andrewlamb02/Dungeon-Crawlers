using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Dungeon_Crawlers
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        SpriteFont gameOverFont;
        public int strength;
        public int agility;
        public int intellect;
        public int stamina;
        public Random rand;
        public Texture2D knightTexture;
        public Texture2D knightTextureRight;
        public Texture2D knightTextureDown;
        public Texture2D knightTextureLeft;
        public Texture2D goldKnightTexture;
        public Texture2D goldKnightTextureRight;
        public Texture2D goldKnightTextureDown;
        public Texture2D goldKnightTextureLeft;
        public Texture2D statsUiBottom;
        public Rectangle playerRectangle;
        public Texture2D lifeBar;
        public Rectangle lifeBarRectangle;
        public Rectangle lifeBarRectangleTwo;
        public Texture2D lifeBarBack;
        public Rectangle lifeBarBackRectangle;
        public Rectangle lifeBarBackRectangleTwo;
        public Texture2D manaBar;
        public Rectangle manaBarRectangle;
        public Rectangle manaBarRectangle2;
        public Texture2D manaBarBack;
        public Rectangle manaBarBackRectangle;
        public Rectangle manaBarBackRectangle2;
        public Rectangle goblinLifeBarRectangle;
        public Texture2D background;
        public Texture2D whiteTexture;
        public Knight knight;
        public Knight knightTwo;
        public SoundEffect sword;
        public Goblin goblin;
        public Goblin goblin2;
        public Goblin goblin3;
        public Goblin goblin4;
        public Goblin goblin5;
        public Goblin goblin6;
        public Goblin goblin7;
        public Goblin goblin8;
        public Meat meat;
        public Rectangle meatRectangle;
        public Texture2D meatTexture;
        public SpeedPowerup speedPowerup;
        public Rectangle speedPowerupRectangle;
        public Texture2D speedPowerupTexture;
        public AttackPowerup attackPowerup;
        public Rectangle attackPowerupRectangle;
        public Texture2D attackPowerupTexture;
        public ManaPotion manaPotion;
        public Rectangle manaPotionRectangle;
        public Texture2D manaPotionTexture;
        public ImmunityPowerup immunityPowerup;
        public Rectangle immunityPowerupRectangle;
        public Texture2D immunityPowerupTexture;
        public int meatChangeTime;
        public int manaPotionChangeTime;
        public HealthBar healthBar;
        public HealthBar healthBar2;
        public HealthBar healthBar3;
        public HealthBar healthBar4;
        public HealthBar healthBar5;
        public HealthBar healthBar6;
        public HealthBar healthBar7;
        public HealthBar healthBar8;
        public Rectangle goblinRec;
        public Rectangle goblinRec2;
        public Texture2D goblinTexture;
        public Rectangle ballistaRec;
        public Texture2D ballistaTexture;
        public Texture2D lightGoblinTexture;
        public Texture2D lightGoblinTextureLeft;
        public Texture2D lightGoblinTextureRight;
        public Texture2D lightGoblinTextureDown;
        public Texture2D portraitOutline;
        public Vector2 position;
        public Texture2D darkGoblinTexture;
        public Texture2D darkGoblinTextureRight;
        public Texture2D darkGoblinTextureLeft;
        public Texture2D darkGoblinTextureDown;
        public Ogre ogre;
        public Rectangle ogreRectangle;
        public Texture2D ogreLeft;
        public Texture2D ogreRight;
        public Texture2D ogreLeftThrown;
        public Texture2D ogreRightThrown;
        public Texture2D ogreLeftDizzyUp;
        public Texture2D ogreRightDizzyUp;
        public Texture2D ogreLeftDizzyDown;
        public Texture2D ogreRightDizzyDown;
        public Texture2D boltTexture;
        public Rock rock;
        public Rock rock2;
        public Rectangle rockRectangle;
        public Texture2D rockTextureLeft;
        public Texture2D rockTextureRight;
        public SoundEffect shield;
        public SoundEffect hurt;
        public Color knightColor;
        public int goblinAttackTime;
        public int goblinAttackTime2;
        public int powerupChangeTime;
        public bool gameStarted;
        public int level;
        public bool twoPlayer;
        public bool win;
        public int levelMessageCounter;
        public bool levelMessage;
        public bool gameOver;
        public int powerupPick;
        public Rectangle ogreLifeBarRectangle;
        public Rectangle boltRectangle;
        public List<Meat> meatList;
        public List<ManaPotion> manaPotionList;
        public List<ImmunityPowerup> immunityPowerupList;
        public List<Goblin> goblinList;
        public List<HealthBar> healthBarList;
        public List<Knight> knightList;
        public List<Bolt> boltList;
        public List<Ballista> ballistaList;
        public List<SpeedPowerup> speedPowerupList;
        public List<AttackPowerup> attackPowerupList;
        public List<Ogre> ogreList;
        public List<Rock> rockList;
        //allows game one to call commands from 
        public InputHandler handlerInput;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Init();
            base.Initialize();
            SetTextures();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            goldKnightTexture = Content.Load<Texture2D>(@"images\knightgold");
            goldKnightTextureRight = Content.Load<Texture2D>(@"images\knightgoldright");
            goldKnightTextureLeft = Content.Load<Texture2D>(@"images\knightgoldleft");
            goldKnightTextureDown = Content.Load<Texture2D>(@"images\knightgolddown");
            knightTexture = Content.Load<Texture2D>(@"images\knight");
            knightTextureRight = Content.Load<Texture2D>(@"images\knightright");
            knightTextureLeft = Content.Load<Texture2D>(@"images\knightleft");
            knightTextureDown = Content.Load<Texture2D>(@"images\knightdown");
            sword = Content.Load<SoundEffect>(@"sounds\swordhit");
            shield = Content.Load<SoundEffect>(@"sounds\shieldhit");
            hurt = Content.Load<SoundEffect>(@"sounds\hurtnoise");
            statsUiBottom = Content.Load<Texture2D>(@"images\statsui");
            lifeBar = Content.Load<Texture2D>(@"images\healthbar");
            lifeBarBack = Content.Load<Texture2D>(@"images\healthbarback");
            manaBar = Content.Load<Texture2D>(@"images\manabar");
            manaBarBack = Content.Load<Texture2D>(@"images\manabarback");
            lightGoblinTexture = Content.Load<Texture2D>(@"images\goblin");
            lightGoblinTextureLeft = Content.Load<Texture2D>(@"images\goblinleft");
            lightGoblinTextureRight = Content.Load<Texture2D>(@"images\goblinright");
            lightGoblinTextureDown = Content.Load<Texture2D>(@"images\goblindown");
            darkGoblinTexture = Content.Load<Texture2D>(@"images\goblindark");
            darkGoblinTextureLeft = Content.Load<Texture2D>(@"images\goblindarkleft");
            darkGoblinTextureRight = Content.Load<Texture2D>(@"images\goblindarkright");
            darkGoblinTextureDown = Content.Load<Texture2D>(@"images\goblindarkdown");
            ballistaTexture = Content.Load<Texture2D>(@"images\ballista");
            background = Content.Load<Texture2D>(@"images\myfloor");
            boltTexture = Content.Load<Texture2D>(@"images\bolt");
            portraitOutline = Content.Load<Texture2D>(@"images\portrait");
            whiteTexture = Content.Load<Texture2D>(@"images\white");
            meatTexture = Content.Load<Texture2D>(@"images\meat");
            manaPotionTexture = Content.Load<Texture2D>(@"images\potion");
            immunityPowerupTexture = Content.Load<Texture2D>(@"images\goldhelmet");
            speedPowerupTexture = Content.Load<Texture2D>(@"images\speedshoes");
            attackPowerupTexture = Content.Load<Texture2D>(@"images\superarrow");
            ogreLeft = Content.Load<Texture2D>(@"images\ogreleft");
            ogreRight = Content.Load<Texture2D>(@"images\ogreright");
            ogreLeftThrown = Content.Load<Texture2D>(@"images\ogreleftthrown");
            ogreRightThrown = Content.Load<Texture2D>(@"images\ogrerightthrown");
            ogreRightDizzyUp = Content.Load<Texture2D>(@"images\ogrerightdizzyup");
            ogreRightDizzyDown = Content.Load<Texture2D>(@"images\ogrerightdizzydown");
            ogreLeftDizzyUp = Content.Load<Texture2D>(@"images\ogreleftdizzyup");
            ogreLeftDizzyDown = Content.Load<Texture2D>(@"images\ogreleftdizzydown");
            rockTextureLeft = Content.Load<Texture2D>(@"images\rockleft");
            rockTextureRight = Content.Load<Texture2D>(@"images\rockright");
            SetTextures();
            /*
            healthBar3.healthBarTexture = lifeBar;
            healthBar4.healthBarTexture = lifeBar;
            healthBar5.healthBarTexture = lifeBar;
            healthBar6.healthBarTexture = lifeBar;
            healthBar7.healthBarTexture = lifeBar;
            healthBar8.healthBarTexture = lifeBar;*/

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            handlerInput.InputControl();

            base.Update(gameTime);
            if (gameStarted == true)
            {
                lifeBarRectangle = new Rectangle(100, 320, (knight.health * 2), 20);
                manaBarRectangle = new Rectangle(100, 350, (knight.mana * 4), 20);
                lifeBarRectangleTwo = new Rectangle((701 - knightTwo.health * 2), 320, (knightTwo.health * 2), 20);
                manaBarRectangle2 = new Rectangle((701 - knightTwo.mana * 4), 350, (knightTwo.mana * 4), 20);
                if (goblinList.Count > 0)
                {
                    healthBar.healthBarRectangle = new Rectangle(goblin.goblinRectangle.X, goblin.goblinRectangle.Y - 10, goblin.health, 5);
                    healthBar2.healthBarRectangle = new Rectangle(goblin2.goblinRectangle.X, goblin2.goblinRectangle.Y - 10, goblin2.health, 5);
                    healthBar4.healthBarRectangle = new Rectangle(goblin3.goblinRectangle.X, goblin3.goblinRectangle.Y - 10, goblin3.health, 5);
                    healthBar5.healthBarRectangle = new Rectangle(goblin4.goblinRectangle.X, goblin4.goblinRectangle.Y - 10, goblin4.health, 5);
                }
                if (ogreList.Count > 0)
                {
                    healthBar6.healthBarRectangle = new Rectangle(250, 270, ogre.health * 3 / 2, 20);
                    healthBar7.healthBarTexture = lifeBarBack;
                }
                if (manaBarRectangle.Width > lifeBarBackRectangle.Width)
                {
                    manaBarRectangle.Width = lifeBarBackRectangle.Width;
                }
                if (manaBarRectangle2.Width > lifeBarBackRectangleTwo.Width)
                {
                    manaBarRectangle2.Width = lifeBarBackRectangleTwo.Width;
                }
                if (manaBarRectangle2.X < lifeBarBackRectangleTwo.X)
                {
                    manaBarRectangle2.X = lifeBarBackRectangleTwo.X;
                }
                meatChangeTime += 1;
                manaPotionChangeTime += 1;
                powerupChangeTime += 1;
                for (int i = 0; i < ballistaList.Count; i++)
                {
                    healthBar3.healthBarRectangle = new Rectangle(ballistaList[i].ballistaRectangle.X, ballistaList[i].ballistaRectangle.Y - 10, ballistaList[i].health, 5);
                }
                for (int i = 0; i < knightList.Count; i++)
                {
                    knightList[i].Update();
                }
                for (int i = 0; i < rockList.Count; i++)
                {
                    rockList[i].Update();
                }
                RemoveMeat();
                RemoveManaPotion();
                RemoveImmunityPowerup();
                RemoveSpeedPowerup();
                RemoveAttackPowerup();
                for (int i = 0; i < ballistaList.Count; i++)
                {
                    if (ballistaList[i].shoot == 0)
                    {
                        Bolt ballistaBolt = new Bolt(boltRectangle, boltTexture, this);
                        ballistaBolt.boltRectangle = new Rectangle(ballistaList[i].ballistaRectangle.X, ballistaList[i].ballistaRectangle.Y + 18, 60, 30);
                        boltList.Add(ballistaBolt);
                    }
                }
                for (int i = 0; i < ogreList.Count; i++)
                {
                    if (ogreList[i].toss == 0 && ogreList[i].stage == 1)
                    {
                        Rock rock = new Rock(rockRectangle, rockTextureLeft, this);
                        rock.rockRectangle = new Rectangle(ogreList[i].ogreRectangle.X, ogreList[i].ogreRectangle.Y + 33, 60, 50);
                        rockList.Add(rock);
                    }
                }
                if (meatChangeTime == 400)
                {
                    meat.meatRectangle = new Rectangle(rand.Next(770), rand.Next(266), 30, 30);
                    meatList.Add(meat);
                    meatChangeTime = 0;
                }
                if (manaPotionChangeTime == 500)
                {
                    manaPotion.manaPotionRectangle = new Rectangle(rand.Next(770), rand.Next(266), 30, 30);
                    manaPotionList.Add(manaPotion);
                    manaPotionChangeTime = 0;
                }
                if (powerupChangeTime == 600)
                {
                    powerupPick = rand.Next(6);
                    powerupChangeTime = 0;
                }
                if (powerupPick == 1 && powerupChangeTime == 1)
                {
                    immunityPowerup.immunityPowerupRectangle = new Rectangle(rand.Next(770), rand.Next(266), 30, 30);
                    immunityPowerupList.Add(immunityPowerup);
                    for (int i = 0; i < immunityPowerupList.Count; i++)
                    {
                        immunityPowerupList[i].immunityPowerupTexture = immunityPowerupTexture;
                    }
                }
                if (powerupPick == 2 && powerupChangeTime == 1)
                {
                    speedPowerup.speedPowerupRectangle = new Rectangle(rand.Next(770), rand.Next(266), 30, 30);
                    speedPowerupList.Add(speedPowerup);
                    for (int i = 0; i < speedPowerupList.Count; i++)
                    {
                        speedPowerupList[i].speedPowerupTexture = speedPowerupTexture;
                    }
                }
                if (powerupPick == 0 && powerupChangeTime == 1)
                {
                    attackPowerup.attackPowerupRectangle = new Rectangle(rand.Next(770), rand.Next(266), 30, 30);
                    attackPowerupList.Add(attackPowerup);
                    for (int i = 0; i < attackPowerupList.Count; i++)
                    {
                        attackPowerupList[i].attackPowerupTexture = attackPowerupTexture;
                    }
                }
                /*for (int i = 0; i < ballistaList.Count; i++)
                {
                    if (ballistaList[i].shoot == 0)
                    {
                        ballistaBolt.boltRectangle = new Rectangle(ballista.ballistaRectangle.X, ballista.ballistaRectangle.Y + 23, 40, 20);
                    }
                }*/
                for (int i = 0; i < boltList.Count; i++)
                {
                    boltList[i].Move("Left");
                }
                for (int i = 0; i < goblinList.Count; i++)
                {
                    goblinList[i].Update();
                    goblinList[i].Stop();
                    goblinList[i].Attack();
                }
                NoMove();
                RemoveGoblins();
                RemoveOgres();
                for (int i = 0; i < ballistaList.Count; i++)
                {
                    ballistaList[i].Update();
                }
                RemoveBallista();
                for (int i = 0; i < boltList.Count; i++)
                {
                    RemoveBolts();
                }
                for (int i = 0; i < boltList.Count; i++)
                {
                    boltList[i].Update();
                }
                for (int i = 0; i < boltList.Count; i++)
                {
                    boltList[i].Hit();
                }
                for (int i = 0; i < ballistaList.Count; i++)
                {
                    ballistaList[i].Update();
                }
                for (int i = 0; i < ogreList.Count; i++)
                {
                    ogreList[i].Update();
                }
                RemoveKnights();
                RemoveBolts();
                RemoveRocks();
                if (goblinList.Count == 0 && ballistaList.Count == 0 && level == 1)
                {
                    level = 2;
                    Level2();
                    levelMessage = true;
                    SetTextures();
                }
                if (goblinList.Count == 0 && ballistaList.Count == 0 && level == 2)
                {
                    level = 3;
                    Level3();
                    levelMessage = true;
                    SetTextures();
                }
                if (goblinList.Count == 0 && ballistaList.Count == 0 && level == 3)
                {
                    level = 4;
                    Level4();
                    levelMessage = true;
                    SetTextures();
                }
                if (goblinList.Count == 0 && ballistaList.Count == 0 && level == 4)
                {
                    level = 5;
                    Level5();
                    levelMessage = true;
                    SetTextures();
                }
                if (ogreList.Count == 0 && level == 5)
                {
                    win = true;
                }
                if (levelMessageCounter > 50)
                {
                    levelMessageCounter = 0;
                    levelMessage = false;
                }
                if (levelMessage == true)
                {
                    levelMessageCounter += 1;
                }
                if (knightList.Count == 0)
                {
                    gameOver = true;
                }
            }
        }
        public void Level2()
    {
            handlerInput = new InputHandler(this);
            font = Content.Load<SpriteFont>("Arial");
            gameOverFont = Content.Load<SpriteFont>("GameOver");
            goblin = new Goblin(this, 50, goblinRec, position, true);
            goblin3 = new Goblin(this, 50, goblinRec, position, true);
            goblin2 = new Goblin(this, 50, goblinRec, position, true);
            goblin.goblinRectangle = new Rectangle(737, 236, 63, 63);
            goblin2.goblinRectangle = new Rectangle(737, 0, 63, 63);
            goblin3.goblinRectangle = new Rectangle(737, 66, 63, 63);
            healthBar = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar2 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar3 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar3 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar4 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            Bolt ballistaBolt = new Bolt(boltRectangle, boltTexture, this);
            for (int i = 0; i < knightList.Count; i++)
            {
                knightList[i].knightRectangle = new Rectangle(0, 0, 62, 62);
            }
            Ballista ballista = new Ballista(this, 50, ballistaRec, position);
            ballistaList = new List<Ballista>();
            ballistaList.Add(ballista);
            goblinList = new List<Goblin>();
            goblinList.Add(goblin);
            goblinList.Add(goblin2);
            goblinList.Add(goblin3);
            boltList = new List<Bolt>();
            boltList.Add(ballistaBolt);
            healthBarList = new List<HealthBar>();
            healthBarList.Add(healthBar);
            healthBarList.Add(healthBar2);
            healthBarList.Add(healthBar3);
            healthBarList.Add(healthBar4);
            levelMessage = true;
    }
        public void Level3()
        {
            handlerInput = new InputHandler(this);
            font = Content.Load<SpriteFont>("Arial");
            gameOverFont = Content.Load<SpriteFont>("GameOver");
            goblin = new Goblin(this, 50, goblinRec, position, true);
            goblin2 = new Goblin(this, 75, goblinRec, position, false);
            goblin3 = new Goblin(this, 50, goblinRec, position, true);
            goblin4 = new Goblin(this, 50, goblinRec, position, true);
            goblin.goblinRectangle = new Rectangle(737, 236, 63, 63);
            goblin2.goblinRectangle = new Rectangle(737, 0, 63, 63);
            goblin3.goblinRectangle = new Rectangle(737, 66, 63, 63);
            goblin4.goblinRectangle = new Rectangle(737, 170, 63, 63);
            healthBar = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar2 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar3 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar3 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar4 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar5 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            Bolt ballistaBolt = new Bolt(boltRectangle, boltTexture, this);
            knight.knightRectangle = new Rectangle(0, 0, 62, 62);
            Ballista ballista = new Ballista(this, 50, ballistaRec, position);
            ballistaList = new List<Ballista>();
            ballistaList.Add(ballista);
            goblinList = new List<Goblin>();
            goblinList.Add(goblin);
            goblinList.Add(goblin2);
            goblinList.Add(goblin3);
            goblinList.Add(goblin4);
            boltList = new List<Bolt>();
            boltList.Add(ballistaBolt);
            healthBarList = new List<HealthBar>();
            healthBarList.Add(healthBar);
            healthBarList.Add(healthBar2);
            healthBarList.Add(healthBar3);
            healthBarList.Add(healthBar4);
            healthBarList.Add(healthBar5);
        }
        public void Level4()
        {
            handlerInput = new InputHandler(this);
            font = Content.Load<SpriteFont>("Arial");
            gameOverFont = Content.Load<SpriteFont>("GameOver");
            goblin = new Goblin(this, 75, goblinRec, position, false);
            goblin3 = new Goblin(this, 75, goblinRec, position, false);
            goblin2 = new Goblin(this, 75, goblinRec, position, false);
            goblin.goblinRectangle = new Rectangle(737, 236, 63, 63);
            goblin2.goblinRectangle = new Rectangle(737, 0, 63, 63);
            goblin3.goblinRectangle = new Rectangle(737, 66, 63, 63);
            healthBar = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar2 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar3 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar3 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar4 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            Bolt ballistaBolt = new Bolt(boltRectangle, boltTexture, this);
            for (int i = 0; i < knightList.Count; i++)
            {
                knightList[i].knightRectangle = new Rectangle(0, 0, 62, 62);
            }
            Ballista ballista = new Ballista(this, 50, ballistaRec, position);
            ballistaList = new List<Ballista>();
            ballistaList.Add(ballista);
            goblinList = new List<Goblin>();
            goblinList.Add(goblin);
            goblinList.Add(goblin2);
            goblinList.Add(goblin3);
            boltList = new List<Bolt>();
            boltList.Add(ballistaBolt);
            healthBarList = new List<HealthBar>();
            healthBarList.Add(healthBar);
            healthBarList.Add(healthBar2);
            healthBarList.Add(healthBar3);
            healthBarList.Add(healthBar4);
            levelMessage = true;
        }
        public void Level5()
        {
            handlerInput = new InputHandler(this);
            font = Content.Load<SpriteFont>("Arial");
            gameOverFont = Content.Load<SpriteFont>("GameOver");
            ogre = new Ogre(ogreRectangle, this, 200, position);
            ogre.ogreRectangle = new Rectangle(525, 0, 125, 125);
            for (int i = 0; i < knightList.Count; i++)
            {
                knightList[i].knightRectangle = new Rectangle(0, 0, 62, 62);
            }
            healthBar7.healthBarRectangle = new Rectangle(250, 270, ogre.health * 3 / 2, 20);
            healthBarList = new List<HealthBar>();
            levelMessage = true;
            ogreList = new List<Ogre>();
            ogreList.Add(ogre);
            ogre.stage = 1;
            healthBarList = new List<HealthBar>();
            healthBarList.Add(healthBar7);
            healthBarList.Add(healthBar6);
        }

                public void Init()
                {
            handlerInput = new InputHandler(this);
            rand = new Random();
            font = Content.Load<SpriteFont>("Arial");
            gameOverFont = Content.Load<SpriteFont>("GameOver");
            ballistaRec = new Rectangle(650, 0, 68, 67);
            knightColor = Color.White;
            knight = new Knight(this, 10, 10, 10, 10, playerRectangle, knightTexture, position, knightColor, false);
            knightTwo = new Knight(this, 10, 10, 10, 10, playerRectangle, knightTexture, position, knightColor, true);
            goblin = new Goblin(this, 50, goblinRec, position, true);
            goblin2 = new Goblin(this, 50, goblinRec, position, true);
            goblin3 = new Goblin(this, 50, goblinRec, position, true);
            goblin4 = new Goblin(this, 50, goblinRec, position, false);
            goblin5 = new Goblin(this, 50, goblinRec, position, true);
            goblin6 = new Goblin(this, 50, goblinRec, position, false);
            goblin7 = new Goblin(this, 50, goblinRec, position, true);
            goblin8 = new Goblin(this, 50, goblinRec, position, false);
            meat = new Meat(meatRectangle);
            meat.meatRectangle = new Rectangle(rand.Next(770), rand.Next(266), 30, 30);
            manaPotion = new ManaPotion(manaPotionRectangle, this);
            manaPotion.manaPotionRectangle = new Rectangle(rand.Next(770), rand.Next(266), 30, 30);
            immunityPowerup = new ImmunityPowerup(immunityPowerupRectangle, this);
            immunityPowerup.immunityPowerupRectangle = new Rectangle(rand.Next(770), rand.Next(266), 30, 30);
            speedPowerup = new SpeedPowerup(speedPowerupRectangle, this);
            attackPowerup = new AttackPowerup(attackPowerupRectangle, this);
            healthBar = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar2 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            Bolt ballistaBolt = new Bolt(boltRectangle, boltTexture, this);
            Rock rock = new Rock(rockRectangle, rockTextureLeft, this);
            healthBar3 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar4 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar5 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            healthBar6 = new HealthBar(ogreLifeBarRectangle, lifeBar, this);
            healthBar7 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            //healthBar8 = new HealthBar(goblinLifeBarRectangle, lifeBar, this);
            goblin.goblinRectangle = new Rectangle(737, 236, 63, 63);
            goblin2.goblinRectangle = new Rectangle(737, 0, 63, 63);
            goblin3.goblinRectangle = new Rectangle(737, 66, 63, 63);
            goblin4.goblinRectangle = new Rectangle(650, 170, 63, 63);
            /*goblin5.goblinRectangle = new Rectangle(650, 150, 63, 63);
            goblin6.goblinRectangle = new Rectangle(737, 126, 63, 63);
            goblin7.goblinRectangle = new Rectangle(737, 63, 63, 63);
            goblin8.goblinRectangle = new Rectangle(737, 150, 63, 63);
            */
            healthBar.healthBarRectangle = new Rectangle(goblin.goblinRectangle.X, goblin.goblinRectangle.Y - 20, goblin.health, 5);
            healthBar2.healthBarRectangle = new Rectangle(goblin2.goblinRectangle.X, goblin2.goblinRectangle.Y - 20, goblin2.health, 5);
            Ballista ballista = new Ballista(this, 50, ballistaRec, position);
            knight.knightRectangle = new Rectangle(0, 0, 62, 62);
            knightTwo.knightRectangle = new Rectangle(0, 0, 62, 62);
            lifeBarRectangle = new Rectangle(100, 320, knight.health * 2, 20);
            lifeBarBackRectangle = new Rectangle(100, 320, knight.health * 2, 20);
            lifeBarRectangleTwo = new Rectangle(481, 320, knightTwo.health * 2, 20);
            lifeBarBackRectangleTwo = new Rectangle(481, 320, knightTwo.health * 2, 20);
            manaBarRectangle = new Rectangle(100, 350, lifeBarRectangle.Width, 20);
            manaBarBackRectangle = new Rectangle(100, 350, lifeBarBackRectangle.Width, 20);
            manaBarRectangle2 = new Rectangle(100, 350, lifeBarRectangle.Width, 20);
            manaBarBackRectangle2 = new Rectangle(100, 350, lifeBarBackRectangle.Width, 20);
            ballistaBolt.boltRectangle = new Rectangle(ballista.ballistaRectangle.X, ballista.ballistaRectangle.Y + 17, 60, 30);
            powerupPick = rand.Next(6);
            goblinAttackTime = 0;
            goblinAttackTime2 = 0;
            gameStarted = false;
            ballistaList = new List<Ballista>();
            ballistaList.Add(ballista);
            goblinList = new List<Goblin>();
            goblinList.Add(goblin);
            goblinList.Add(goblin2);
            /*goblinList.Add(goblin3);
            goblinList.Add(goblin4);
            goblinList.Add(goblin5);
            goblinList.Add(goblin6);
            goblinList.Add(goblin7);
            goblinList.Add(goblin8);*/
            healthBarList = new List<HealthBar>();
            healthBarList.Add(healthBar);
            healthBarList.Add(healthBar2);
            healthBarList.Add(healthBar3);
            knightList = new List<Knight>();
            boltList = new List<Bolt>();
            boltList.Add(ballistaBolt);
            rockList = new List<Rock>();
            meatList = new List<Meat>();
            meatList.Add(meat);
            manaPotionList = new List<ManaPotion>();
            manaPotionList.Add(manaPotion);
            immunityPowerupList = new List<ImmunityPowerup>();
            speedPowerupList = new List<SpeedPowerup>();
            attackPowerupList = new List<AttackPowerup>();
            ogreList = new List<Ogre>();
            powerupChangeTime = 0;
            meatChangeTime = 0;
            manaPotionChangeTime = 0; 
            level = 0;
            win = false;
            levelMessage = false;
            gameOver = false;
            twoPlayer = false;
            levelMessageCounter = 0;
                }
                public void SetTextures()
                {
                    for (int i = 0; i < goblinList.Count; i++)
                    {
                        if (goblinList[i].isLight == true)
                        {
                            goblinList[i].goblinTexture = lightGoblinTexture;
                        }
                        else
                        {
                            goblinList[i].goblinTexture = darkGoblinTexture;
                        }
                    }
                    for (int i = 0; i < ballistaList.Count; i++)
                    {
                        ballistaList[i].ballistaTexture = ballistaTexture;
                    }
                    for (int i = 0; i < meatList.Count; i++)
                    {
                        meatList[i].meatTexture = meatTexture;
                    }
                    for (int i = 0; i < manaPotionList.Count; i++)
                    {
                        manaPotionList[i].manaPotionTexture = manaPotionTexture;
                    }
                    for (int i = 0; i < immunityPowerupList.Count; i++)
                    {
                        immunityPowerupList[i].immunityPowerupTexture = immunityPowerupTexture;
                    }
                    for (int i = 0; i < healthBarList.Count; i++)
                    {
                        healthBarList[i].healthBarTexture = lifeBar;
                    }
                    for (int i = 0; i < boltList.Count; i++)
                    {
                        boltList[i].boltTexture = boltTexture;
                    }
                    for (int i = 0; i < rockList.Count; i++)
                    {
                        rockList[i].rockTexture = rockTextureLeft;
                    }
                    for (int i = 0; i < knightList.Count; i++)
                    {
                        if (knightList[i].isGold == true)
                        {
                            knightList[i].knightTexture = goldKnightTextureRight;
                        }
                        else
                        {
                            knightList[i].knightTexture = knightTextureRight;
                        }
                    }
                    for (int i = 0; i < ogreList.Count; i++)
                    {
                        ogreList[i].ogreTexture = ogreLeft;
                    }
                }

                public void RemoveGoblins()
                {
                    int toRemove = -1;
                    for (int i = 0; i < goblinList.Count; i++)
                    {
                        if (goblinList[i].health <= 0)
                            toRemove = i;
                    }
                    if (toRemove != -1)
                    {
                        goblinList.RemoveAt(toRemove);
                        toRemove = -1;
                    }
                }

                public void RemoveOgres()
                {
                    int toRemove = -1;
                    for (int i = 0; i < ogreList.Count; i++)
                    {
                        if (ogreList[i].health <= 0)
                            toRemove = i;
                    }
                    if (toRemove != -1)
                    {
                        ogreList.RemoveAt(toRemove);
                        toRemove = -1;
                    }
                }
        public void RemoveMeat()
        {
            int toRemove = -1;
            for (int i = 0; i < meatList.Count; i++)
            {
                for (int j = 0; j < knightList.Count; j++)
                {
                    if (knightList.Count > 0)
                    {
                        if (meatList[i].meatRectangle.Intersects(knightList[j].knightRectangle) || meatChangeTime == 500)
                        {
                            toRemove = i;
                        }
                    }
                }
            }
            if (toRemove != -1)
            {
                meatList.RemoveAt(toRemove);
                toRemove = -1;
            }
        }
        public void RemoveImmunityPowerup()
        {
            int toRemove = -1;
            for (int i = 0; i < immunityPowerupList.Count; i++)
            {
                for (int j = 0; j < knightList.Count; j++)
                {
                    if (knightList.Count > 0)
                    {
                        if (immunityPowerupList[i].immunityPowerupRectangle.Intersects(knightList[j].knightRectangle) || powerupChangeTime == 600)
                        {
                            toRemove = i;
                        }
                    }
                }
            }
            if (toRemove != -1)
            {
                immunityPowerupList.RemoveAt(toRemove);
                toRemove = -1;
            }
        }
        public void RemoveAttackPowerup()
        {
            int toRemove = -1;
            for (int i = 0; i < attackPowerupList.Count; i++)
            {
                for (int j = 0; j < knightList.Count; j++)
                {
                    if (knightList.Count > 0)
                    {
                        if (attackPowerupList[i].attackPowerupRectangle.Intersects(knightList[j].knightRectangle) || powerupChangeTime == 600)
                        {
                            toRemove = i;
                        }
                    }
                }
            }
            if (toRemove != -1)
            {
                attackPowerupList.RemoveAt(toRemove);
                toRemove = -1;
            }
        }
        public void RemoveSpeedPowerup()
        {
            int toRemove = -1;
            for (int i = 0; i < speedPowerupList.Count; i++)
            {
                for (int j = 0; j < knightList.Count; j++)
                {
                    if (knightList.Count > 0)
                    {
                        if (speedPowerupList[i].speedPowerupRectangle.Intersects(knightList[j].knightRectangle) || powerupChangeTime == 600)
                        {
                            toRemove = i;
                        }
                    }
                }
            }
            if (toRemove != -1)
            {
                speedPowerupList.RemoveAt(toRemove);
                toRemove = -1;
            }
        }
        public void RemoveManaPotion()
        {
            int toRemove = -1;
            for (int i = 0; i < manaPotionList.Count; i++)
            {
                for (int j = 0; j < knightList.Count; j++)
                {
                    if (knightList.Count > 0)
                    {
                        if (manaPotionList[i].manaPotionRectangle.Intersects(knightList[j].knightRectangle) || manaPotionChangeTime == 500)
                        {
                            toRemove = i;
                        }
                    }
                }
            }
            if (toRemove != -1)
            {
                manaPotionList.RemoveAt(toRemove);
                toRemove = -1;
            }
        }
        public void RemoveKnights()
        {
            int toRemove = -1;
            for (int i = 0; i < knightList.Count; i++)
            {
                if (knightList[i].alive == false)
                    toRemove = i;
            }
            if (toRemove != -1)
            {
                knightList.RemoveAt(toRemove);
                toRemove = -1;
            }
        }
        public void RemoveBallista()
        {
            int toRemove = -1;
            for (int i = 0; i < ballistaList.Count; i++)
            {
                if (ballistaList[i].health <= 0)
                    toRemove = i;
            }
            if (toRemove != -1)
            {
                ballistaList.RemoveAt(toRemove);
                toRemove = -1;
            }
        }
        public void RemoveBolts()
        {
            int _index = -1;
            for (int i = 0; i < boltList.Count; i++)
            {
                if (boltList[i].toRemove == true)
                {
                    _index = i;
                }
            }
            if (_index != -1)
                boltList.RemoveAt(_index);
        }
        public void RemoveRocks()
        {
            int _index = -1;
            for (int i = 0; i < rockList.Count; i++)
            {
                if (rockList[i].toRemove == true)
                {
                    _index = i;
                }
            }
            if (_index != -1)
                rockList.RemoveAt(_index);
        }
        public void NoMove()
        {
            for (int i = 0; i < goblinList.Count; i++)
                {
                    for (int j = 0; j < goblinList.Count; j++)
                    {
                        if (goblinList[i].goblinRectangle.Intersects(goblinList[j].goblinRectangle) && goblinList[i].Equals(goblinList[j]) == false && i < j)
                        {
                            goblinList[j].goblinMove = false;
                            goblinList[j].collidingG = true;
                            goblinList[i].collidingG = false;
                        }
                        else
                        {
                            goblinList[j].collidingG = false;
                        }
                    }
                }
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            Rectangle _temprec = new Rectangle(0, 380, 800, 100);
            Vector2 _tempvec = new Vector2(10, 380);
            Vector2 _tempvec2 = new Vector2(555, 380);
            Rectangle _temprect = new Rectangle(5, 300, 79, 79);
            Rectangle _temprect2 = new Rectangle(716, 300, 79, 79);
            Vector2 _tempvect = new Vector2(160, 348);
            Vector2 _tempvector0 = new Vector2(160, 318);
            Vector2 _tempvect1 = new Vector2(531, 348);
            Vector2 _tempvector3 = new Vector2(531, 318);
            Vector2 _tempvector = new Vector2(270, 130);
            Vector2 _tempvector1 = new Vector2(300, 130);
            Vector2 _tempvector4 = new Vector2(280, 130);
            Vector2 _tempvector5 = new Vector2(290, 130);
            Vector2 _tempvector6 = new Vector2(323, 267);
            Vector2 _tempvector2 = new Vector2(325, 130);
            Vector2 _tempvecto = new Vector2(260, 380);
            Vector2 _tempve = new Vector2(275, 200);
            Rectangle _tempr = new Rectangle(265, 205, 280, 20);
            Rectangle _temprectangle = new Rectangle(0, 0, 800, 296);
            Rectangle _temprectangle0 = new Rectangle(91, 310, lifeBarBackRectangle.Width + 20, 70);
            Rectangle _temprectangle3 = new Rectangle(469, 310, lifeBarBackRectangle.Width + 20, 70);
            Rectangle _temprectan = new Rectangle(265, 130, 275, 55);
            Rectangle _temprecta = new Rectangle(270, 130, 260, 50);
            Rectangle _temprectang = new Rectangle(320, 130, 166, 50);
            Rectangle _tempre = new Rectangle(0, 296, 800, 92);
            Rectangle _temprectangle1 = new Rectangle(0, 296, 90, 85);
            Rectangle _temprectangle2 = new Rectangle(710, 295, 90, 85);
            spriteBatch.Draw(whiteTexture, _tempre, Color.Black);
            spriteBatch.Draw(background, _temprectangle, Color.White);
            spriteBatch.Draw(portraitOutline, _temprectangle1, Color.White);
            spriteBatch.Draw(statsUiBottom, _temprec, Color.Red);
            spriteBatch.Draw(whiteTexture, _temprectangle0, Color.Gold);
            spriteBatch.Draw(lifeBarBack, lifeBarBackRectangle, Color.White);
            spriteBatch.Draw(lifeBar, lifeBarRectangle, Color.White);
            if (twoPlayer == true)
            {
                spriteBatch.Draw(portraitOutline, _temprectangle2, Color.White);
                spriteBatch.Draw(whiteTexture, _temprectangle3, Color.Gold);
                spriteBatch.Draw(lifeBarBack, lifeBarBackRectangleTwo, Color.White);
                spriteBatch.Draw(lifeBar, lifeBarRectangleTwo, Color.White);
                spriteBatch.Draw(manaBarBack, manaBarBackRectangle2, Color.White);
                spriteBatch.Draw(manaBar, manaBarRectangle2, Color.White);
                spriteBatch.Draw(goldKnightTexture, _temprect2, Color.White);
                spriteBatch.DrawString(font, "Strength: " + knightTwo.strength + "\nAgility: " + knightTwo.agility + "\nIntellect: " + knightTwo.intellect + "\nStamina: " + knightTwo.stamina, _tempvec2, Color.White);
                spriteBatch.DrawString(font, "Health: " + knightTwo.health, _tempvector3, Color.Black);
                spriteBatch.DrawString(font, "Mana: " + knightTwo.mana, _tempvect1, Color.Black);
            }
            spriteBatch.Draw(manaBarBack, manaBarBackRectangle, Color.White);
            spriteBatch.Draw(manaBar, manaBarRectangle, Color.White);
            for (int i = 0; i < knightList.Count; i++)
            {
                spriteBatch.Draw(knightList[i].knightTexture, knightList[i].knightRectangle, knightList[i].knightColor);
            }
            for (int i = 0; i < healthBarList.Count; i++)
            {
                spriteBatch.Draw(healthBarList[i].healthBarTexture, healthBarList[i].healthBarRectangle, Color.White);
            }
            for (int i = 0; i < goblinList.Count; i++)
            {
                spriteBatch.Draw(goblinList[i].goblinTexture, goblinList[i].goblinRectangle, goblinList[i].goblinColor);
            }
            for (int i = 0; i < ogreList.Count; i++)
            {
                spriteBatch.Draw(ogreList[i].ogreTexture, ogreList[i].ogreRectangle, ogreList[i].ogreColor);
            }
            for (int i = 0; i < rockList.Count; i++)
            {
                spriteBatch.Draw(rockList[i].rockTexture, rockList[i].rockRectangle, Color.White);
            }
            for (int i = 0; i < ballistaList.Count; i++)
            {
                spriteBatch.Draw(ballistaList[i].ballistaTexture, ballistaList[i].ballistaRectangle, ballistaList[i].ballistaColor);
            }
            for (int i = 0; i < boltList.Count; i++)
            {
                spriteBatch.Draw(boltList[i].boltTexture, boltList[i].boltRectangle, Color.White);
            }
            for (int i = 0; i < meatList.Count; i++)
            {
                spriteBatch.Draw(meatList[i].meatTexture, meatList[i].meatRectangle, Color.White);
            }
            for (int i = 0; i < manaPotionList.Count; i++)
            {
                spriteBatch.Draw(manaPotionList[i].manaPotionTexture, manaPotionList[i].manaPotionRectangle, Color.White);
            }
            for (int i = 0; i < immunityPowerupList.Count; i++)
            {
                spriteBatch.Draw(immunityPowerupList[i].immunityPowerupTexture, immunityPowerupList[i].immunityPowerupRectangle, Color.White);
            }
            for (int i = 0; i < attackPowerupList.Count; i++)
            {
                spriteBatch.Draw(attackPowerupList[i].attackPowerupTexture, attackPowerupList[i].attackPowerupRectangle, Color.White);
            }
            for (int i = 0; i < speedPowerupList.Count; i++)
            {
                spriteBatch.Draw(speedPowerupList[i].speedPowerupTexture, speedPowerupList[i].speedPowerupRectangle, Color.White);
            }
            spriteBatch.DrawString(font, "Strength: " + knight.strength + "\nAgility: " + knight.agility + "\nIntellect: " + knight.intellect + "\nStamina: " + knight.stamina, _tempvec, Color.White);
            spriteBatch.DrawString(font, "Controls: \n(WASD) Move (Arrows)\n(R) Attack (K)\n(E) Special (L)", _tempvecto, Color.White);
            spriteBatch.Draw(knightTexture, _temprect, Color.White);
            spriteBatch.DrawString(font, "Health: " + knight.health, _tempvector0, Color.Black);
            spriteBatch.DrawString(font, "Mana: " + knight.mana, _tempvect, Color.Black);
            //Debug lines
            //spriteBatch.DrawString(font, "goblins intersecting: " + goblin.goblinRectangle.Intersects(goblin2.goblinRectangle) + "\ngoblin2 intersecting player:" + knight.knightRectangle.Intersects(goblin2.goblinRectangle) + "\ngoblin intersecting player: " + knight.knightRectangle.Intersects(goblin.goblinRectangle), Vector2.Zero, Color.Black);
            //spriteBatch.DrawString(font, "Goblin Attack (25): " + goblinAttackTime + "Goblin2 Attack (25): " + goblinAttackTime2, Vector2.Zero, Color.Black);
            //spriteBatch.DrawString(font, "Knight Attack(25): " + knight.knightAttackTime + "\nKnight Attack Time Counter: " + knight.knightAttackTimeCounter + "\nKnight Hurt" + knight.hurt + "\nKnight hurt Counter: " + knight.hurtCounter, Vector2.Zero, Color.Black);
            //spriteBatch.DrawString(font, "Bolt List: " + boltList.Count, Vector2.Zero, Color.White);
            //spriteBatch.DrawString(font, "level 1: " + level1 + "\nlevel2: " + level2 + "\nlevel3; " + level3 + "\nlevel1Passed: " + level1Passed + "\nlevel2passed: " + level2Passed + "\nlevel3Passed: " + level3Passed, Vector2.Zero, Color.White);
            //spriteBatch.DrawString(font, "levelmessagetext: " + levelMessage + "\nlevelmessageCounter: " + levelMessageCounter, Vector2.Zero, Color.White);
            //spriteBatch.DrawString(font, "\nmeat : " + meatList.Count, Vector2.Zero, Color.White);
            //spriteBatch.DrawString(font, "meat change time: " + meatChangeTime, Vector2.Zero, Color.White);
            //spriteBatch.DrawString(font, "immune: " + knight.immunity + "\nimmunity Color Counter: " + knight.immunityColorCounter, Vector2.Zero, Color.White);
            //spriteBatch.DrawString(font, "PowerupPick: " + powerupPick, Vector2.Zero, Color.White);
            //spriteBatch.DrawString(font, "\nPowerupchange Time: " + powerupChangeTime, Vector2.Zero, Color.White);
            //spriteBatch.DrawString(font, "\nimmuniutyPowerup: " + speedPowerupList.Count, Vector2.Zero, Color.White);
            //spriteBatch.DrawString(font, "ogreRectangle " + ogreRectangle, Vector2.Zero, Color.Red);
            //spriteBatch.DrawString(font, "\nogreList " + ogreList.Count, Vector2.Zero, Color.Red);
            if (ogreList.Count > 0)
            {
                spriteBatch.DrawString(font, "Health: " + ogre.health, _tempvector6, Color.Black);
            }
            for (int i = 0; i < ballistaList.Count; i++)
            {
                //spriteBatch.DrawString(font, "ballista shoot: " + ballistaList[i].shoot, Vector2.Zero, Color.White);
            }
                if (gameOver == true)
                {
                    spriteBatch.Draw(lifeBar, _temprecta, Color.Black);
                    spriteBatch.DrawString(gameOverFont, "GAME OVER", _tempvector1, Color.Red);
                    spriteBatch.Draw(lifeBar, _tempr, Color.Black);
                    spriteBatch.DrawString(font, "Press Backspace To Reset", _tempve, Color.White);
                }
                if (win == true)
                {
                    spriteBatch.Draw(lifeBar, _temprectang, Color.Black);
                    spriteBatch.DrawString(gameOverFont, "YOU WIN", _tempvector2, Color.Green);
                    spriteBatch.Draw(lifeBar, _tempr, Color.Black);
                    spriteBatch.DrawString(font, "Press Backspace To Reset", _tempve, Color.White);
                }
                if (levelMessage == true && level == 1)
                {
                    spriteBatch.Draw(lifeBar, _temprecta, Color.Black);
                    spriteBatch.DrawString(gameOverFont, "Level One", _tempvector1, Color.White);
                }
                if (levelMessage == true && level == 2)
                {
                    spriteBatch.Draw(lifeBar, _temprecta, Color.Black);
                    spriteBatch.DrawString(gameOverFont, "Level Two", _tempvector1, Color.White);
                }
                if (levelMessage == true && level == 3)
                {
                    spriteBatch.Draw(lifeBar, _temprecta, Color.Black);
                    spriteBatch.DrawString(gameOverFont, "Level Three", _tempvector4, Color.White);
                }
                if (levelMessage == true && level == 4)
                {
                    spriteBatch.Draw(lifeBar, _temprecta, Color.Black);
                    spriteBatch.DrawString(gameOverFont, "Level Four", _tempvector5, Color.White);
                }
                if (gameStarted == false)
                {
                    spriteBatch.Draw(lifeBar, _temprectan, Color.Black);
                    spriteBatch.DrawString(font, "Press Enter for 1 Player\nPress Space for 2 Player", _tempvector, Color.White);
                }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
