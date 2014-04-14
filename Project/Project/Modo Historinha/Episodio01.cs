﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

using game_states;
using Microsoft.Xna.Framework.Input;
using Project;
using Microsoft.Xna.Framework.Media;


class Episodio01 : GameState
{
    #region Cena 01
    #region Dialogo 01
    string fala01 = "Era uma vez, em uma pequena cidade... Dois irmãos muito parecidos por serem gêmeos. O menino se chama Cosme, e o seu sonho é um dia se tornar um grande engenheiro.";
    string fala02 = "E a menina se chama Maria. Seu sonho é lançar um livro com muitas histórias, que farão mais pessoas sonharem com as maravilhas do mundo.";
    #endregion
    #region Exercicio 01 - Modo Historinha
    string pergunta00 = "Cosme e Maria nasceram juntos, por isso os dois tem a mesma idade: sete anos. Espera, qual dos dois números é o número sete?";
    string alternativa00 = "7";//certo
    string alternativa01 = "1";//errado

    #endregion
    #region Dialogo 02
    string fala03 = "Muito bem! Apesar dos dois terem a mesma idade, Cosme gosta de dizer que ele é o irmão mais velho porque ele é um pouquinho mais alto que Maria.";
    string fala04 = "Por outro lado... Maria diz que é a mais velha porque ela precisa cuidar de Cosme toda vez que ele causa alguma confusão, como se fosse sua irmã mais velha!";
    string fala05 = "Epa... Acho que entramos em um assunto delicado para os irmãos. Vamos falar de outra coisa. Cosme e Maria tem alguns amigos que adoram jogar futebol!";
    string fala06 = "Os dois são amigos muito queridos. A menina se chama Serafina. Ela adora animais e tem um pequeno cachorro de estimação que adora levar para passear.";
    string fala07 = "O menino se chama Apuã. Ele gosta de visitar Cosme e Maria para brincar, sempre vindo com uma brincadeira diferente!";
    #endregion
    #region Exercicio 02 - Modo Historinha
    string pergunta10 = "Esses são os amigos que formam a turma de Cosme e Maria. A turma é composta por Cosme, Maria, Apuã e Serafina. Quantas pessoas existem na turma?";
    string alternativa02 = "4";//certo
    string alternativa03 = "2";//errado
    string alternativa10 = "3";//errado

    #endregion
    #region Dialogo 03
    string fala08 = "Dessa vez, Apuã quer convidar todo mundo para brincar de futebol. Uma partida entre duas equipes! Cosme e Maria contra Apuã e Serafina.";
    string fala09 = "Para organizar as equipes, Cosme entregou um número para cada amigo. Maria ganhou o número 3;  Apuã ganhou o número 1;Serafina ganhou o número 2; Cosme ganhou o número 4.";
    #endregion
    #region Exercicio 03 - Modo Historinha
    string pergunta20 = "Qual a ordem certa que eles devem ficar para dividir os times?";
    string alternativa20 = "Maria, 3";
    string alternativa21 = "Apuã, 1";
    string alternativa22 = "Serafina, 2";
    string alternativa23 = "Cosme, 4";
    #endregion
    #region Dialogo 04
    string fala10 = "Espera, há algo de errado com o que Apuã está pensando!";
    #endregion
    #region Exercicio 04 - Modo Historinha
    string pergunta30 = "Um dos times tem mais jogadores do que o outro. Qual time tem mais jogadores?";
    string alternativa30 = "TimeA";
    string alternativa31 = "TimeB";
    #endregion
    #region Exercicio 05 - Modo Historinha
    string pergunta40 = "Apuã está dizendo que Cosme, Serafina e ele joguem contra Maria. Mas os times de futebol sempre devem ter a mesma quantidade de pessoas! Quantas pessoas devem ficar em cada time?";
    string alternativa40 = "2";
    string alternativa41 = "3";
    string alternativa42 = "5";
    #endregion
    #region Dialogo 05
    string fala11 = "Maria percebe que Apuã estava tentando enganar a todos. Apuã pede desculpas e diz que estava apenas brincando.";
    string fala12 = "Apuã treinou bastante algumas técnicas de futebol conhecidas como firulas. Passar a bola por entre as pernas do adversário; chutar a bola por cima... Dessa vez, Apuã diz que não perderá para os irmãos gêmeos!";
    string fala13 = "Cosme não quer perder para Apuã! Cosme pede para Maria encontra-lo no campo de futebol que fica próximo ao rio. Antes que Maria possa respondê-lo, ele sai da casa, ansioso pela partida!";
    string fala14 = "O que Maria não conseguiu falar para Cosme é que ela precisa buscar água no rio! Vamos rápido Maria, para que dê tempo de jogar futebol!";
    #endregion
    #endregion
    #region Bate-Bola
    #endregion
    #region Variaveis
    //--------------------------------------------------------------//
    string[] dialogo01;
    string[] dialogo02;
    string[] dialogo03;
    string dialogo04;
    string[] dialogo05;

    //--------------------------------------------------------------//
    ModoHistorinha Exercicio01, Exercicio02, Exercicio03, Exercicio04, Exercicio05;
    //--------------------------------------------------------------//
    int Segundos = 0;
    bool parte1 = false;
    bool parte2 = false;
    bool parte3 = false;
    bool parte4 = false;
    bool parte5 = false;
    bool exercicio1 = false;
    bool exercicio2 = false;
    bool exercicio3 = false;
    bool exercicio4 = false;
    bool exercicio5 = false;
    bool primeiro = false;
    bool segundo = false;
    bool terceiro = false;
    bool quarto = false;
    bool quinto = false;
    //--------------------------------------------------------------//
    int Incremento0 = 0;
    int Incremento1 = 0;
    int Incremento2 = 0;
    int Incremento3 = 0;
    //--------------------------------------------------------------//
    SpriteFont arial;
    Vector2 posicaoText;
    
    int FalasPorSegundo = 10;
    int ritimo = 10;
    int mile;
    string texto = "";
    int indice = 0;
    bool pauseFlag;
    private bool contentLoaded;
    int CaixaTexto;
    int zerar = 1;
    Color cor;
    int selecionar = 0; //seleciona a musica
    bool repetir = true;
    //-------------------------------------------//
    Song audio01, audio02, audio03;
    List<Song> Album;
    #endregion

    // Desça o código até Initialize
    public Episodio01(int id, Game1 parent)
        : base(id, parent)
    {

        Initialize();

    }
    protected override void Initialize()
    {

        if (!initialized)
        {
            base.Initialize();
            LoadContent();
            //Aqui você muda a posição do texto;
            //spriteBatch = new spriteBatch(parent.GraphicsDevice);
            posicaoText = new Vector2(20, 600);
            dialogo01 = new string[2] { fala01, fala02 };
            dialogo02 = new string[5] { fala03, fala04, fala05, fala06, fala07 };
            dialogo03 = new string[2] { fala08, fala09 };
            dialogo04 = fala10;
            dialogo05 = new string[4] { fala11, fala12, fala13, fala14 };
            Exercicio01 = new ModoHistorinha(parent.Content, pergunta00, alternativa00, alternativa01, 1, arial, 2);
            Exercicio02 = new ModoHistorinha(parent.Content, pergunta10, alternativa02, alternativa03, alternativa10, 1, arial, 3);
            Exercicio03 = new ModoHistorinha(parent.Content, pergunta20, alternativa20, alternativa21, alternativa22, alternativa23, 1, arial, 4, true);
            Exercicio04 = new ModoHistorinha(parent.Content, pergunta30, alternativa30, alternativa31, 1, arial, 2);
            Exercicio05 = new ModoHistorinha(parent.Content, pergunta40, alternativa40, alternativa41, alternativa42, 1, arial, 3);
            enterTransitionDuration = 50;
            exitTransitionDuration = 50;
            Album = new List<Song>() { audio01, audio02, audio03 };
            
        }
    }
    public override void Update(GameTime tempo)
    {
        if (!pauseFlag)
        {

            base.Update(tempo);
            //MediaPlayer.IsRepeating = false;
            if (repetir && selecionar < Album.Count)
            {
                MediaPlayer.Play(Album[selecionar]);
                repetir = false;
            }
            if (Album[selecionar].Duration == MediaPlayer.PlayPosition && selecionar < Album.Count-1)
            {
                selecionar += selecionar < Album.Count ? 1 : 0;
                repetir = true;
            }
            if (stateEntered)
            {
                CaixaTexto = (int)arial.MeasureString(texto).X * zerar;
                if (CaixaTexto > 800 &&  texto[indice-1] == ' ')
                {
                    texto += "\n";
                    zerar = 0;
                    
                }
                if (KeyboardHelper.IsKeyDown(Keys.Escape))
                {
                    KeyboardHelper.LockKey(Keys.Escape);
                    if (parent.EnterState((int)StatesIdList.PAUSE, false))
                    {
                        alpha = 0.5f;
                        pauseFlag = true;
                        stateEntered = false;
                    }
                }
                else if (KeyboardHelper.KeyReleased(Keys.Escape))
                {
                    KeyboardHelper.UnlockKey(Keys.Escape);
                }
            }

        }
    }

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Begin();
        cor = Color.White * alpha;
       
        SpriteBatch.DrawString(arial, Segundos.ToString(), new Vector2(400, 700), cor);
        //*
        
        #region Desenho
        if (!primeiro)
        {
            if (!parte1)
            {
                if (!pauseFlag)
                {
                    if (indice < dialogo01[Incremento0].Length) { texto += dialogo01[Incremento0][indice]; }
                    indice = indice + (indice < dialogo01[Incremento0].Length ? 1 : 0);
                    if (texto.Length == dialogo01[Incremento0].Length +1)
                    {
                        mile += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                        Segundos = mile / 1000;
                        if (Segundos != 0 && Segundos % FalasPorSegundo == 0)
                        {

                            Incremento0++;
                            indice = 0;
                            zerar = 1;
                            texto = "";
                            FalasPorSegundo += ritimo;
                            if (Incremento0 == dialogo01.Length)
                            {
                                parte1 = true;

                            }
                        }
                    }
                }
                SpriteBatch.DrawString(arial, texto, posicaoText, cor);


               
            }

            if (parte1 && !exercicio1)
            {

                mile = 0;
                FalasPorSegundo = ritimo;
                Exercicio01.Atualizar();
                Exercicio01.Desenhar(SpriteBatch);
                exercicio1 = Exercicio01.Continuar();
                primeiro = exercicio1;
            }
        }

        if (primeiro && !segundo)
        {
            if (!parte2)
            {
                if (!pauseFlag)
                {
                    if (indice < dialogo02[Incremento1].Length) { texto += dialogo02[Incremento1][indice]; }
                    indice = indice + (indice < dialogo02[Incremento1].Length ? 1 : 0);
                    if (texto.Length == dialogo02[Incremento1].Length+1)
                    {
                        mile += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                        Segundos = mile / 1000;
                        if (Segundos != 0 && Segundos % FalasPorSegundo == 0)
                        {

                            Incremento1++;
                            indice = 0;
                            texto = "";
                            FalasPorSegundo += ritimo;
                            if (Incremento1 == dialogo02.Length)
                            {
                                parte2 = true;

                            }
                        }

                    }
                }
                SpriteBatch.DrawString(arial, texto, posicaoText, cor);
                
            }
            if (!exercicio2 && parte2)
            {
                mile = 0;
                FalasPorSegundo = ritimo;
                Exercicio02.Atualizar();
                Exercicio02.Desenhar(SpriteBatch);
                exercicio2 = Exercicio02.Continuar();
                segundo = exercicio2;
            }

        }
        if (primeiro && segundo && !terceiro)
        {
            if (!parte3)
            {
                if (!pauseFlag)
                {
                    if (indice < dialogo03[Incremento2].Length) { texto += dialogo03[Incremento2][indice]; }
                    indice = indice + (indice < dialogo03[Incremento2].Length ? 1 : 0);
                    if (texto.Length == dialogo03[Incremento2].Length+1)
                    {
                        mile += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                        Segundos = mile / 1000;
                        if (Segundos != 0 && Segundos % FalasPorSegundo == 0)
                        {

                            Incremento2++;
                            indice = 0;
                            texto = "";
                            FalasPorSegundo += ritimo;
                            if (Incremento2 == dialogo03.Length)
                            {
                                parte3 = true;

                            }
                        }
                    }
                }
                SpriteBatch.DrawString(arial, texto, posicaoText, cor);
                
            }
            if (parte3 && !exercicio3)
            {
                mile = 0;
                FalasPorSegundo = ritimo;
                Exercicio03.Atualizar();
                Exercicio03.Desenhar(SpriteBatch);
                exercicio3 = Exercicio03.Continuar();
                terceiro = exercicio3;
            }

        }
        if (primeiro && segundo && terceiro)
        {
            SpriteBatch.DrawString(arial, "Fim da Demo", posicaoText, cor);
            if ((int)Segundos % FalasPorSegundo == 0 && (int)Segundos > 0)
            {

            }
        }
        #endregion
        //*/
        SpriteBatch.End();
    }
    protected override void LoadContent()
    {
        if (!contentLoaded)
        {
            arial = parent.Content.Load<SpriteFont>("Fonte/Verdana");
            audio01 = parent.Content.Load<Song>("Narrar/MH001");
            audio02 = parent.Content.Load<Song>("Narrar/MH002");
            audio03 = parent.Content.Load<Song>("Narrar/MH003");
            contentLoaded = true;
        }

    }
    #region Transitioning
    public override void EnterState(bool freezeBelow)
    {
        if (!exitingState)
        {
            base.EnterState(freezeBelow);
            LoadContent();
            pauseFlag = false;
        }
    }
    public override void EnterState()
    {
        base.EnterState();
        pauseFlag = false;
    }
    public override void ExitState()
    {
        if (!enteringState)
        {
            base.ExitState();
            parent.Content.Unload();
            contentLoaded = false;
        }
    }
    #endregion
    


}

