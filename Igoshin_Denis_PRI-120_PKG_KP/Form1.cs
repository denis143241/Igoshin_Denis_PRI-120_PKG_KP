using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Igoshin_Denis_PRI_120_PKG_KP
{
    public enum FLOWER_STATE
    {
        SPROUT,
        LITTLE,
        TEEN,
        BIG,
        DEAD
    }
    public partial class Form1 : Form
    {
        double angle = 3, angleX = -96, angleY = 0, angleZ = -30;
        double sizeX = 1, sizeY = 1, sizeZ = 1;

        double translateX = -9, translateY = -60, translateZ = -10;
        double cameraSpeed;
        float global_time = 0;
        double deltaXFish = 0;
        bool isFishLeft = true;
        bool isWatering, isTeapotTook;
        float deltaColor = 0;
        Bookcase bookcase = new Bookcase();

        string photoPart1Textute = "esenin_part1.png";
        string photoPart2Textute = "esenin_part2.png";
        string photoPart3Textute = "esenin_part3.png";
        string eseninTexture = "esenin.png";
        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();

        uint photoPart1Sign, photoPart2Sign, photoPart3Sign, eseninSign;

        Photo[] partsOfPhoto = new Photo[3];

        //Переменные для работы с текстурами
        uint stripesSign, mayakSign;
        int imageId;
        string stripesTexture = "scale.jpg";
        string mayakTexture = "mayak.jpeg";

        FLOWER_STATE flowerState;

        bool photoCompleted;
        bool isPressedBook;

        //Взрыв (система частиц)
        private readonly Explosion explosion= new Explosion(1, 10, 1, 300, 1000);
        bool isSalut = false;

        double deltaXTeapot, deltaZTeapot, deltaZWater, deltaRotateTeapot;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
                cameraSpeed = (double)numericUpDown1.Value;
            AnT.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AnT.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                angle = 3; angleX = -90; angleY = 0; angleZ = 0;
                sizeX = 1; sizeY = 1; sizeZ = 1;
                translateX = -40; translateY = 10; translateZ = -25;
                label4.Text = "Это книжный шкаф";
                WMP.controls.stop();
                isPressedBook = false;
                button1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                button2.Visible = false;
            }
            if (comboBox2.SelectedIndex == 1)
            {
                translateX = -10; translateY = -30; translateZ = -78;
                angleX = -30;
                angleZ = 40;
                label4.Text = "Полей цветок!";
                button2.Visible = true;
                WMP.controls.stop();
                isPressedBook = false;
                if (flowerState == FLOWER_STATE.BIG) label4.Text = "ОСТАНОВИСЬ!!!";
                if (flowerState == FLOWER_STATE.DEAD)
                {
                    label4.Text = "Press F";
                    button1.Visible = true;
                    label5.Visible = true;
                    label5.Text = "Живая вода";
                    button2.Visible = false;
                }
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
            }
            if (comboBox2.SelectedIndex == 2)
            {
                angle = 3; angleX = -90; angleY = 0; angleZ = 0;
                sizeX = 1; sizeY = 1; sizeZ = 1;
                translateX = -40; translateY =  -15; translateZ = -35;
                label4.Text = "Нажми на книгу!";
                button1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                button2.Visible = false;
            }
            if (comboBox2.SelectedIndex == 3)
            {
                translateX = -15; translateY = -35; translateZ = -48;
                angleX = -30;
                angleZ = 0;
                if (!photoCompleted)
                {
                    label4.Text = "Собери фото!";
                    label6.Visible = true;
                    label7.Visible = true;
                    label8.Visible = true;
                }
                 else label4.Text = "Есенин жив!";
                WMP.controls.stop();
                isPressedBook = false;
                button1.Visible = false;
                label5.Visible = false;
                button2.Visible = false;
            }
            if (comboBox2.SelectedIndex == 4)
            {
                angle = 1; angleX = -90; angleY = 0; angleZ = -90;
                sizeX = 1; sizeY = 1; sizeZ = 1;
                translateX = -45; translateY = -30; translateZ = -25;
                label4.Text = "Это фрактал!";
                WMP.controls.stop();
                isPressedBook = false;
                button1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                button2.Visible = false;
            }
            if (comboBox2.SelectedIndex == 5)
            {
                translateX = -40; translateY = -30; translateZ = -15;
                angleX = -65;
                angleZ = 0;
                label4.Text = "Рыбка плавает... ";
                WMP.controls.stop();
                isPressedBook = false;
                button1.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                button2.Visible = false;
            }
            AnT.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowerState = FLOWER_STATE.DEAD;
            button2.Visible = false;
            button1.Visible = true;
            label5.Visible = true;
            deltaColor = 0.5f;
        }

        private void AnT_MouseClick(object sender, MouseEventArgs e)
        {
            switch (comboBox2.SelectedIndex)
            {
                case 2:
                    if (!isPressedBook)
                    {
                        if (e.X > 120 && e.X < 230 && e.Y < 280 && e.Y > 140)
                        {
                            isPressedBook = true;
                            WMP.URL = @"mayak.mp3";
                            WMP.controls.play();
                            label4.Text = "Послушайте!";
                        }
                    }
                    break;
                case 1:
                    if (!isPressedBook)
                    {
                        if (e.X > 360 && e.X < 450 && e.Y < 150 && e.Y > 70)
                        {
                            wateringTheFlower();
                        }
                    }
                    break;
            }
        }

        private void wateringTheFlower()
        {
            isTeapotTook = true;
        }

        private void chooseFlowerState()
        {
            isTeapotTook = false;
            isWatering = false;
            deltaZWater = 0;
            deltaZTeapot = 0;
            deltaXTeapot = 0;
            deltaRotateTeapot = 0;
            switch (flowerState)
            {
                case FLOWER_STATE.SPROUT:
                    flowerState = FLOWER_STATE.LITTLE;
                    break;
                case FLOWER_STATE.LITTLE:
                    flowerState = FLOWER_STATE.TEEN;
                    break;
                case FLOWER_STATE.TEEN:
                    flowerState = FLOWER_STATE.BIG;
                    label4.Text = "ОСТАНОВИСЬ!!!";
                    break;
                case FLOWER_STATE.BIG:
                    flowerState = FLOWER_STATE.DEAD;
                    label4.Text = "Press F";
                    button1.Visible = true;
                    label5.Visible = true;
                    deltaColor = 0.5f;
                    label5.Text = "Живая вода";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flowerState = FLOWER_STATE.SPROUT;
            button1.Visible = false;
            label5.Visible = false;
            button2.Visible = true;
            deltaColor = 0;
        }

        private void AnT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                translateY -= cameraSpeed;

            }
            if (e.KeyCode == Keys.S)
            {
                translateY += cameraSpeed;
            }
            if (e.KeyCode == Keys.A)
            {
                translateX += cameraSpeed;
            }
            if (e.KeyCode == Keys.D)
            {
                translateX -= cameraSpeed;

            }
            if (e.KeyCode == Keys.ControlKey)
            {
                translateZ += cameraSpeed;

            }
            if (e.KeyCode == Keys.Space)
            {
                translateZ -= cameraSpeed;
            }
            if (e.KeyCode == Keys.Q)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        angleX += angle;

                        break;
                    case 1:
                        angleY += angle;

                        break;
                    case 2:
                        angleZ += angle;

                        break;
                    default:
                        break;
                }
            }
            if (e.KeyCode == Keys.E)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        angleX -= angle;
                        break;
                    case 1:
                        angleY -= angle;
                        break;
                    case 2:
                        angleZ -= angle;
                        break;
                    default:
                        break;
                }
            }
            if (e.KeyCode == Keys.Z)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        sizeX += 0.1;
                        break;
                    case 1:
                        sizeY += 0.1;
                        break;
                    case 2:
                        sizeZ += 0.1;
                        break;
                    default:
                        break;
                }
            }
            if (e.KeyCode == Keys.X)
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        sizeX -= 0.1;
                        break;
                    case 1:
                        sizeY -= 0.1;
                        break;
                    case 2:
                        sizeZ -= 0.1;
                        break;
                    default:
                        break;
                }

            }
            if (e.KeyCode == Keys.U)
            {
                switch (comboBox2.SelectedIndex)
                {
                    case 3:
                        if (!partsOfPhoto[0].isCompleted)
                        {
                            partsOfPhoto[0].deltaY += 0.1;
                            if (partsOfPhoto[0].deltaY > 0.9) partsOfPhoto[0].isCompleted = true;
                        }
                        break;

                    default:
                        break;
                }

            }
            if (e.KeyCode == Keys.I)
            {
                switch (comboBox2.SelectedIndex)
                {
                    case 3:
                        if (!partsOfPhoto[2].isCompleted)
                        {
                            partsOfPhoto[2].deltaY -= 0.1;
                            if (partsOfPhoto[2].deltaY < -0.9) partsOfPhoto[2].isCompleted = true;
                        }
                        break;
                    default:
                        break;
                }

            }
        }


        public Form1()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }


        private void RenderTimer_Tick(object sender, EventArgs e)
        {
            global_time += (float)RenderTimer.Interval / 1000;
            Draw();
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form about = new About();
            about.ShowDialog();

        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // инициализация openGL (glut)
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);

            Il.ilInit();
            Il.ilEnable(Il.IL_ORIGIN_SET);

            // цвет очистки окна
            Gl.glClearColor(255, 255, 255, 1);

            // настройка порта просмотра
            Gl.glViewport(0, 0, AnT.Width, AnT.Height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(60, (float)AnT.Width / (float)AnT.Height, 0.1, 900);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            stripesSign = genImage(stripesTexture);
            mayakSign = genImage(mayakTexture);

            photoPart1Sign = genImage(photoPart1Textute);
            photoPart2Sign = genImage(photoPart2Textute);
            photoPart3Sign = genImage(photoPart3Textute);
            eseninSign = genImage(eseninTexture);

            partsOfPhoto[0] = new Photo(photoPart1Sign, 0, false);
            partsOfPhoto[1] = new Photo(photoPart2Sign, 0, true);
            partsOfPhoto[2] = new Photo(photoPart3Sign, 0, false);


            flowerState = FLOWER_STATE.SPROUT;
            photoCompleted = false;
            isPressedBook = false;
            isWatering = false;
            isTeapotTook = false;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            cameraSpeed = 5;

            RenderTimer.Start();
        }



        private void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glClearColor(255, 255, 255, 1);
            Gl.glLoadIdentity();
            Gl.glPushMatrix();
            Gl.glRotated(angleX, 1, 0, 0); Gl.glRotated(angleY, 0, 1, 0); Gl.glRotated(angleZ, 0, 0, 1);
            Gl.glTranslated(translateX, translateY, translateZ);
            Gl.glScaled(sizeX, sizeY, sizeZ);
            Gl.glColor3f(0.07f, 0.04f, 0.56f);
            explosion.Calculate(global_time);

            bookcase.drawFloor(deltaColor);
            bookcase.drawWalls(deltaColor);
            bookcase.drawBookcase(deltaColor);
            bookcase.drawFlowerpot(flowerState, deltaColor);
            isWatering = bookcase.drawWateringCan(isTeapotTook,deltaXTeapot, deltaZTeapot, deltaRotateTeapot, deltaColor);
            bookcase.drawCylinders(deltaColor);
            bookcase.drawMayakBook(mayakSign, deltaColor);
            bookcase.drawBooks(52, 45, 37.5, deltaColor);
            bookcase.drawBooks(68, 45, 11.5, deltaColor);
            bookcase.drawBooks(27, 45, 24.5, deltaColor);
            bookcase.drawBooks(35, 45, 24.5, deltaColor);
            photoCompleted = bookcase.drawPartsOfPhoto(partsOfPhoto);
            bookcase.drawPhotoFrame(photoCompleted, eseninSign, deltaColor);

            //Салют в честь собранного фото Есенина
            if (photoCompleted)
            {
                if (!isSalut)
                {
                    explosion.SetNewPosition(10, 65, 35);
                    explosion.SetNewPower(5);
                    explosion.Boooom(global_time);
                    isSalut = true;
                    label4.Text = "Есенин жив!";
                }
            }

            //Нажали ли на чайник
            if (isTeapotTook)
            {
                if (!isWatering)
                {
                    if (deltaXTeapot > 10 && deltaZTeapot > 10)
                    {
                        deltaRotateTeapot -= 5;
                    }
                    else
                    {
                        deltaXTeapot += 1;
                        deltaZTeapot += 1;
                    }
                }
                else isTeapotTook = false;
            }

            if (isWatering)
            {
                bookcase.drawWater(deltaZWater);
                if (deltaZWater < 9)
                { 
                    chooseFlowerState();

                }
                else deltaZWater -= 1;
            }
           

            drawFractal();
            bookcase.drawPicture();
            bookcase.drawAquarium();
            bookcase.drawFish(deltaXFish, isFishLeft);

            if (isFishLeft && deltaXFish > 10)
            {
                deltaXFish = 0;
                isFishLeft = false;
            } else if (!isFishLeft && deltaXFish > 10) {
                deltaXFish = 0;
                isFishLeft = true;
            }
            deltaXFish += 0.1;
            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }

        private uint genImage(string image)
        {
            uint sign = 0;
            Il.ilGenImages(1, out imageId);
            Il.ilBindImage(imageId);
            if (Il.ilLoadImage(image))
            {
                int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
                int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
                int bitspp = Il.ilGetInteger(Il.IL_IMAGE_BITS_PER_PIXEL);
                switch (bitspp)
                {
                    case 24:
                        sign = MakeGlTexture(Gl.GL_RGB, Il.ilGetData(), width, height);
                        break;
                    case 32:
                        sign = MakeGlTexture(Gl.GL_RGBA, Il.ilGetData(), width, height);
                        break;
                }
            }
            Il.ilDeleteImages(1, ref imageId);
            return sign;
        }

        private static uint MakeGlTexture(int Format, IntPtr pixels, int w, int h)
        {
            uint texObject;
            Gl.glGenTextures(1, out texObject);
            Gl.glPixelStorei(Gl.GL_UNPACK_ALIGNMENT, 1);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texObject);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
            Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
            Gl.glTexEnvf(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_REPLACE);
            switch (Format)
            {

                case Gl.GL_RGB:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGB, w, h, 0, Gl.GL_RGB, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

                case Gl.GL_RGBA:
                    Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, Gl.GL_RGBA, w, h, 0, Gl.GL_RGBA, Gl.GL_UNSIGNED_BYTE, pixels);
                    break;

            }
            return texObject;
        }

        public void drawFractal()
        {
            Gl.glPushMatrix();

            Gl.glTranslated(1, 35, 40);

            drawSpiral(15, 5);
            Gl.glEnd();
            Gl.glPopMatrix();
        }

        public void drawSpiral(int depth, float size)
        {
            if (depth <= 0 && size <= 0.005) return;
            Gl.glColor3f(0,0,0);
            Glut.glutSolidSphere(0.5, 32, 32);
            Gl.glColor3f(0.3f, 0, 0.9f);
            Glut.glutWireSphere(0.5, 32, 12);
            Gl.glTranslated(0, -1.5*size,0);
            Gl.glRotated(30, 1, 0, 0);
            depth--;
            size /= 1.1f;
            drawSpiral(depth, size);
        }
    }


    public class Photo
    {
        public uint sign;
        public double deltaY;
        public bool isCompleted;

        public Photo(uint sign, double deltaY, bool isCompleted)
        {
            this.sign = sign;
            this.deltaY = deltaY;
            this.isCompleted = isCompleted;
        }
    }

}
