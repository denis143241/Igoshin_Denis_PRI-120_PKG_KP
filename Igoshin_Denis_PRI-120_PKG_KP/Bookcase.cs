using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.DevIl;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Igoshin_Denis_PRI_120_PKG_KP
{
    class Bookcase
    {
        //Пол
        public void drawFloor(float deltaColor)
        {
            float colorXFloor = 0.17f - deltaColor;
            float colorYFloor = 0.14f -deltaColor;
            float colorZFloor = 0.12f - deltaColor;
            

            double deltaYFloor = 100;

            //пол
            Gl.glPushMatrix();
            Gl.glColor3f(colorXFloor, colorYFloor, colorZFloor);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(100, 0, 0);
            Gl.glVertex3d(100, 50, 0);
            Gl.glVertex3d(0, 50, 0);
            Gl.glEnd();
            Gl.glPopMatrix();

        }

        //Стены
        public void drawWalls(float deltaColor)
        {
            float wallR = 0.5f -deltaColor;
            float wallG = 0.3f -deltaColor;
            float wallB = 0.2f -deltaColor;

            Gl.glPushMatrix();
            Gl.glColor3f(wallR, wallG, wallB);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, 50, 0);
            Gl.glVertex3d(0, 50, 80);
            Gl.glVertex3d(0, 0, 80);
            Gl.glEnd();

            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex3d(0, 50, 0);
            Gl.glVertex3d(100, 50, 0);
            Gl.glVertex3d(100, 50, 80);
            Gl.glVertex3d(0, 50, 80);
            Gl.glEnd();

            Gl.glLineWidth(4f);

            Gl.glColor3f(0.07f, 0f, 0f);
            Gl.glTranslated(0.5, 49.5, 0);
            Gl.glBegin(Gl.GL_LINES);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, 0, 80);
            Gl.glEnd();

            Gl.glPopMatrix();          
        }

        //Книжный шкаф
        public void drawBookcase(float deltaColor)
        {
            float colorWhite = 0.7f - deltaColor;
            float colorWoodR = 0.9f -deltaColor;
            float colorWoodG = 0.5f -deltaColor;
            float colorWoodB = 0.25f -deltaColor;
            Gl.glPushMatrix();

            Gl.glTranslated(50, 45, 0);

            Gl.glPushMatrix();

            float deltaZWhite = 13;
            float deltaXWhite = 10;
            for (int i = 0; i <4; i++)
            {
               
                Gl.glPushMatrix();
                if (i % 2 == 0)
                    Gl.glTranslated(-35, 0, -0.4 + deltaZWhite * i);
                else Gl.glTranslated(-35 + deltaXWhite, 0, -0.4 + deltaZWhite * i);
                Gl.glScaled(0.2, 0.8, 1.11f);
                Gl.glColor3f(colorWhite, colorWhite, colorWhite);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

               
                Gl.glPushMatrix();
                if (i % 2 == 0)
                    Gl.glTranslated(15, 0, -0.4 + deltaZWhite * i);
                else Gl.glTranslated(15 - deltaXWhite, 0, -0.4+ deltaZWhite * i);
                Gl.glScaled(0.2, 0.8, 1.11f);
                Gl.glColor3f(colorWhite, colorWhite, colorWhite);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();

            }

            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-10, 0, 6);
            double deltaZ = 0;
            for (int i = 0; i < 4; i++)
            {
                Gl.glPushMatrix();

                Gl.glTranslated(0,0,deltaZ);
                Gl.glScaled(6.5f, 0.8, 0.1f);
                Gl.glColor3f(colorWoodR, colorWoodG, colorWoodB);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);

                deltaZ += 13;
                Gl.glPopMatrix();
            }
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        //Горшок с цветком
        public void drawFlowerpot(FLOWER_STATE flowerState, float deltaColor)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(20, 45, 46);

            Gl.glPushMatrix();
            Gl.glScaled(1, 1, 1);
            Gl.glColor3f(0.98f -deltaColor, 0.89f -deltaColor, 0.83f -deltaColor);
            Glut.glutSolidCylinder(4, 5, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(4, 5, 10, 10);
            Gl.glTranslated(0,0,5);
            Gl.glColor3f(0.98f -deltaColor, 0.89f -deltaColor, 0.83f -deltaColor);
            Glut.glutSolidCylinder(5, 2, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(2f);
            Glut.glutWireCylinder(5, 2, 12, 32);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, 0, 6.9);
            Gl.glScaled(1, 1, 0.1f);
            Gl.glColor3f(0.23f -deltaColor, 0.18f -deltaColor, 0.16f -deltaColor);
            Glut.glutSolidSphere(4.5, 32, 32);
            Gl.glPopMatrix();

            drawFlower(flowerState, deltaColor);

            Gl.glPopMatrix();
        }

        //Цветок в зависимости от его состояний
        public void drawFlower(FLOWER_STATE flowerState, float deltaColor)
        {
            switch (flowerState)
            {
                case FLOWER_STATE.SPROUT:
                    Gl.glPushMatrix();
                    Gl.glTranslated(0, 0, 8);
                    Gl.glRotated(-45, 0, 0, 1);
                    Gl.glScaled(0.3, 0.1, 1);
                    Gl.glColor3f(0.06f -deltaColor, 0.62f - deltaColor, 0.11f - deltaColor);
                    Glut.glutSolidSphere(1, 32, 32);
                    Gl.glPopMatrix();
                    break;
                case FLOWER_STATE.LITTLE:
                    Gl.glPushMatrix();
                    Gl.glTranslated(0, 0, 8);
                    Gl.glRotated(-45, 0, 0, 1);
                    Gl.glScaled(0.2, 0.1, 1);
                    Gl.glColor3f(0.06f - deltaColor, 0.62f - deltaColor, 0.11f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();
                    break;
                case FLOWER_STATE.TEEN:
                    Gl.glPushMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(0, 0, 10);
                    Gl.glRotated(-45, 0, 0, 1);
                    Gl.glScaled(0.08, 0.08, 0.9);
                    Gl.glColor3f(0.06f - deltaColor, 0.62f - deltaColor, 0.11f - deltaColor);
                    Glut.glutSolidSphere(4, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(2.3, 0.2, 8);
                    Gl.glRotated(70, 0, 1, 0);
                    Gl.glScaled(0.2, 0.4, 0.9);
                    Gl.glColor3f(0.06f - deltaColor, 0.62f - deltaColor, 0.11f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(-0.5, 0, 12.9);
                    Gl.glRotated(80, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.3);
                    Gl.glColor3f(0.06f - deltaColor, 0.62f - deltaColor, 0.11f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPopMatrix();
                    break;
                case FLOWER_STATE.BIG:
                    Gl.glPushMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(0, 0, 10);
                    Gl.glRotated(-45, 0, 0, 1);
                    Gl.glScaled(0.08, 0.08, 0.9);
                    Gl.glColor3f(0.06f - deltaColor, 0.62f - deltaColor, 0.11f - deltaColor);
                    Glut.glutSolidSphere(4, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(2.3, 0.2, 8);
                    Gl.glRotated(70, 0, 1, 0);
                    Gl.glScaled(0.2, 0.4, 0.9);
                    Gl.glColor3f(0.06f - deltaColor, 0.62f - deltaColor, 0.11f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glPushMatrix();
                    Gl.glTranslated(-0.5, 0, 13);
                    Gl.glRotated(80, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.3);
                    Gl.glColor3f(1f - deltaColor, 1f - deltaColor, 0.11f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(-2, 0, 12.6);
                    Gl.glRotated(80, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.4);
                    Gl.glColor3f(0.56f - deltaColor, 0.19f - deltaColor, 0.82f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(-0.8, 1, 13.3);
                    Gl.glRotated(80, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.4);
                    Gl.glColor3f(0.56f - deltaColor, 0.19f - deltaColor, 0.82f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(-1.2, -1.5, 13.3);
                    Gl.glRotated(80, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.4);
                    Gl.glColor3f(0.56f - deltaColor, 0.19f - deltaColor, 0.82f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(0.8, -0.7, 13.2);
                    Gl.glRotated(80, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.4);
                    Gl.glColor3f(0.56f - deltaColor, 0.19f - deltaColor, 0.82f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(0.8, 0.7, 13.2);
                    Gl.glRotated(80, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.4);
                    Gl.glColor3f(0.56f - deltaColor, 0.19f - deltaColor, 0.82f - deltaColor);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();
                    Gl.glPopMatrix();

                    Gl.glPopMatrix();
                    break;
                case FLOWER_STATE.DEAD:

                    Gl.glPushMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(0, 0, 10);
                    Gl.glRotated(-45, 0, 0, 1);
                    Gl.glScaled(0.08, 0.08, 0.2);
                    Gl.glColor3f(0.05f, 0.21f, 0.05f);
                    Glut.glutSolidSphere(4, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(2.3, -1, 8);
                    Gl.glRotated(90, 0, 1, 0);
                    Gl.glScaled(0.2, 0.4, 0.8);
                    Gl.glColor3f(0.05f, 0.21f, 0.05f);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(-2, 2, 7.5);
                    Gl.glRotated(45, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.35);
                    Gl.glColor3f(0.2f, 0.06f, 0.31f);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(-2, 0, 7.5);
                    Gl.glRotated(45, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.35);
                    Gl.glColor3f(0.2f, 0.06f, 0.31f);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(-4, -1.7, 7.5);
                    Gl.glRotated(45, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.35);
                    Gl.glColor3f(0.2f, 0.06f, 0.31f);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(-8, -1.7, 3);
                    Gl.glRotated(30, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.35);
                    Gl.glColor3f(0.2f, 0.06f, 0.31f);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();

                    Gl.glPushMatrix();
                    Gl.glTranslated(-10, 0.7, 3);
                    Gl.glRotated(80, 0, 1, 0);
                    Gl.glScaled(0.3, 0.2, 0.4);
                    Gl.glColor3f(0.2f, 0.06f, 0.31f);
                    Glut.glutSolidSphere(3, 32, 32);
                    Gl.glPopMatrix();
                    Gl.glPopMatrix();
                    break;
            }
        }

        public void drawCylinders(float deltaColor)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(45, 45, 20);
            Gl.glPushMatrix();
            Gl.glScaled(1, 1, 1);
            Gl.glColor3f(0.98f - deltaColor, 0.55f - deltaColor, 0.69f - deltaColor);
            Glut.glutSolidCylinder(4, 7, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(4, 7, 10, 10);
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            Gl.glTranslated(10, 0, 0);
            Gl.glScaled(1, 1, 1);
            Gl.glColor3f(0.56f - deltaColor, 0.56f - deltaColor, 0.98f - deltaColor);
            Glut.glutSolidCylinder(4, 8, 32, 32);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCylinder(4, 8, 10, 10);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        //Чайник
        public bool drawWateringCan(bool isTook,double deltaXTeapot, double deltaZTeapot, double deltaRotate,
            float deltaColor)
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.7f - deltaColor, 0.7f - deltaColor, 0.64f - deltaColor);
            Gl.glTranslated(40, 45, 50);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glRotated(180, 0, 1, 0);

            bool flag = false;

            if (isTook)
            {
                Gl.glTranslated(deltaZTeapot, deltaXTeapot, 0);

                if (deltaRotate != 0)
                {
                    Gl.glRotated(deltaRotate, 0, 0, 1);
                    if (deltaRotate <= -70) flag = true;
                } 
            }
            Gl.glPushMatrix();
            Gl.glScaled(1, 1, 1);
            Glut.glutSolidTeapot(5);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(3f);
            Glut.glutWireTeapot(5);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            return flag;
        }

        //Вода из чайника
        public void drawWater(double deltaZWater)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(23, 45, 55);
            Gl.glTranslated(0, 0, 0 - deltaZWater);
            Gl.glScaled(0.3, 0.1, 0.4);
            Gl.glColor3f(0.06f, 0.3f, 1f);
            Glut.glutSolidSphere(3, 32, 32);
            Gl.glPopMatrix();
        }

        //Книга Маяковского
        public void drawMayakBook(uint mayakTexture, float deltaColor)
        {
            Gl.glPushMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(33, 45, 37.5);
            Gl.glScaled(0.7f, 0.1, 0.9);
            Gl.glColor3f(0, 0, 0);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);

            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(25, 40, 37.5);
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, mayakTexture);
            Gl.glPushMatrix();
            Gl.glRotated(90, 0, 1, 0);
            Gl.glTranslated(0, 0, 5);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(0, 5, 0);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(2, 5, 0);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(2, 5, 2);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0, 5, 2);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glTranslated(4, -1, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(0, 5, 6.7);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(0, 5, 0);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(-8, 5, 0);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(-8, 5, 6.7);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();
            Gl.glDisable(Gl.GL_TEXTURE_2D);
            Gl.glPopMatrix();
            Gl.glPopMatrix();
        }

        //Стопка книг
        public void drawBooks(double x, double y, double z, float deltaColor)
        {
            Gl.glPushMatrix();

            for (int i = 0; i <6; i++)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(x - i * 2, y, z);
                Gl.glRotated(-90, 0, 0, 1);
                Gl.glScaled(0.7f, 0.15, 0.9);
                if (i % 2 == 0)
                    Gl.glColor3f(0.6f - deltaColor, 0.2f - deltaColor, 0.17f - deltaColor);
                else Gl.glColor3f(0.4f - deltaColor, 0.1f - deltaColor, 0.18f - deltaColor);
                Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();
            }
           

            Gl.glPopMatrix();
        }


        //Фоторамка
        public void drawPhotoFrame(bool flag, uint eseninTexture, float deltaColor)
        {
            Gl.glPushMatrix();

            Gl.glTranslated(20, 47.5, 35.2);
            Gl.glRotated(-35, 1, 0, 0);

            Gl.glPushMatrix();
            Gl.glScaled(0.6f, 0.01f, 0.7f);
            Gl.glColor3f(0.3f - deltaColor, 0.3f - deltaColor, 0.3f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-3, -0.4, 0);
            Gl.glScaled(0.05f, 0.05f, 0.7f);
            Gl.glColor3f(0.4f - deltaColor, 0.3f - deltaColor, 0.2f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);

            Gl.glTranslated(123, -1, 0);
            Gl.glColor3f(0.4f - deltaColor, 0.3f - deltaColor, 0.2f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(0, -0.4, 3.25);
            Gl.glScaled(0.6f, 0.05f, 0.05f);
            Gl.glColor3f(0.4f - deltaColor, 0.3f - deltaColor, 0.2f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);

            Gl.glTranslated(0, -1, -130);
            Gl.glColor3f(0.4f - deltaColor, 0.3f - deltaColor, 0.2f - deltaColor);
            Glut.glutSolidCube(10);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCube(10);
            Gl.glPopMatrix();

            if (flag)
            {
                Gl.glPushMatrix();
                Gl.glTranslated(-3, -5.5, -4.6);
                Gl.glEnable(Gl.GL_TEXTURE_2D);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, eseninTexture);
                Gl.glPushMatrix();
                Gl.glRotated(90, 0, 1, 0);
                Gl.glBegin(Gl.GL_QUADS);
                Gl.glVertex3d(0, 5, 6.7);
                Gl.glTexCoord2f(0, 0);
                Gl.glVertex3d(0, 5, 0);
                Gl.glTexCoord2f(0, 1);
                Gl.glVertex3d(-8, 5, 0);
                Gl.glTexCoord2f(1, 1);
                Gl.glVertex3d(-8, 5, 6.7);
                Gl.glTexCoord2f(1, 0);
                Gl.glEnd();
                Gl.glPopMatrix();
                Gl.glDisable(Gl.GL_TEXTURE_2D);
                Gl.glPopMatrix();
            }

            Gl.glPopMatrix();
        }

        //Куски фото
        public bool drawPartsOfPhoto(Photo[] partsOfPhoto)
        {
            Gl.glPushMatrix();
            Gl.glTranslated(10, 37, 28);
            Gl.glRotated(90, 1, 0, 0);
            Gl.glRotated(180, 0, 1, 0);
            bool flag = true;
            for (int i = 0; i<3; i++)
            {
                if (partsOfPhoto[i].isCompleted == false) flag = false;
            }
            if (!flag)
            for (int i = 0; i<3; i++)
            {
                    Gl.glPushMatrix();
                    Gl.glTranslated(-i * 3, 0, 0);
                    Gl.glEnable(Gl.GL_TEXTURE_2D);
                    Gl.glBindTexture(Gl.GL_TEXTURE_2D, partsOfPhoto[i].sign);
                    Gl.glPushMatrix();

                    Gl.glTranslated(0 - partsOfPhoto[i].deltaY,0, 5);
                    Gl.glBegin(Gl.GL_QUADS);
                    Gl.glVertex3d(0, 5, 0);
                    Gl.glTexCoord2f(0, 0);
                    Gl.glVertex3d(2, 5, 0);
                    Gl.glTexCoord2f(0, 1);
                    Gl.glVertex3d(2, 5, 5);
                    Gl.glTexCoord2f(1, 1);
                    Gl.glVertex3d(0, 5, 5);
                    Gl.glTexCoord2f(1, 0);
                    Gl.glEnd();

                    Gl.glPopMatrix();
                    Gl.glDisable(Gl.GL_TEXTURE_2D);
                Gl.glPopMatrix();
            } 
            Gl.glPopMatrix();

            return flag;
        }

        //Картина на стене
        public void drawPicture()
        {
            Gl.glPushMatrix();
            Gl.glColor3f(0.1f, 0.1f, 0.1f);
            Gl.glTranslated(6, 12, 14);
            Gl.glRotated(90, 0, 0, 1);
            
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(0, 5, 0);
            Gl.glTexCoord2f(0, 0);
            Gl.glVertex3d(30, 5, 0);
            Gl.glTexCoord2f(0, 1);
            Gl.glVertex3d(30, 5, 30);
            Gl.glTexCoord2f(1, 1);
            Gl.glVertex3d(0, 5, 30);
            Gl.glTexCoord2f(1, 0);
            Gl.glEnd();
            Gl.glPopMatrix();
        }
        
        //Аквариум
        public void drawAquarium()
        {
                Gl.glPushMatrix();
                Gl.glTranslated(40,45,9);
                Gl.glRotated(-90, 0, 0, 1);
                Gl.glScaled(0.7f, 1.4f, 0.6);
            Gl.glColor3f(0.35f, 0.5f, 0.95f);
            Glut.glutSolidCube(10);
                Gl.glColor3f(0, 0, 0);
                Gl.glLineWidth(5f);
                Glut.glutWireCube(10);
                Gl.glPopMatrix();
        }

        //Рыбка в аквариуме
        public void drawFish(double deltaX, bool left)
        {
            Gl.glPushMatrix();
            if (left)
            {
                Gl.glTranslated(45 - deltaX, 45, 12.3);
            }
            else
            {
                Gl.glTranslated(35 + deltaX, 45, 12.3);
                Gl.glRotated(180, 0, 0, 1);
            }
            

            Gl.glPushMatrix();
            Gl.glScaled(0.1f, 0.05f, 0.05);
            Gl.glColor3f(1,0,0);
            Glut.glutSolidSphere(10,12,12);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireSphere(10,12,12);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(1.5,0,0);
            Gl.glRotated(-90, 0, 1, 0);
            Gl.glScaled(0.05f, 0.05f, 0.4f);
            Gl.glColor3f(1, 0, 0);
            Glut.glutSolidCone(10,2, 12, 12);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireCone(10,2, 12, 12);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-0.4, -0.45, 0.3);
            Gl.glScaled(0.01f, 0.01f, 0.01f);
            Gl.glColor3f(1,1,1);
            Glut.glutSolidSphere(10, 12, 12);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireSphere(9.2, 12, 12);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-0.4, 0.45, 0.3);
            Gl.glScaled(0.01f, 0.01f, 0.01f);
            Gl.glColor3f(1, 1, 1);
            Glut.glutSolidSphere(10, 12, 12);
            Gl.glColor3f(0, 0, 0);
            Gl.glLineWidth(5f);
            Glut.glutWireSphere(9.2, 12, 12);
            Gl.glPopMatrix();

            Gl.glPopMatrix();
        }
    }
}