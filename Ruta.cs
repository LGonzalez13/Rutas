using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyControlInv
{
    class Ruta
    {
        private Base primero;
        private int numeroBases;

        public Ruta()
        {
            numeroBases = 0;
        }

        public void agregarEnInicio(Base p)
        {
            if (primero == null)
            {
                primero = p;
                primero.quienSigue = primero;
                primero.anterior = primero;
            }
            else
            {
                primero.anterior = p;
                Base temp = primero;
                primero = p;
                primero.quienSigue = temp;

            }
            numeroBases++;
        }

        public void agregar(Base p)
        {
            if (primero == null)
            {
                primero = p;
                primero.quienSigue = primero;
                primero.anterior = primero;
            }
            else
                agregar(p, primero);
        }

        private void agregar(Base p, Base ultimo)
        {
            if (ultimo.quienSigue == primero)
            {
                p.quienSigue = primero;
                ultimo.quienSigue = p;
                ultimo.quienSigue.anterior = ultimo;
                primero.anterior = p;
            }
                
            else
                agregar(p, ultimo.quienSigue);
        }


        public Base buscar(string nombre)
        {
            Base temp = primero;
            while (temp != null && temp.nombre != nombre)
            {
                temp = temp.quienSigue;
            }
            return temp;

        }

        public void eliminar(string nombre)
        {
            if (primero != null)
            {
                if(primero.nombre != nombre)
                {
                    if (primero.quienSigue != primero)
                    {
                        eliminar(primero.quienSigue, nombre);
                    }
                }
                else
                {
                    if (primero.quienSigue != primero)
                    {
                        primero.anterior.quienSigue = primero.quienSigue;
                        primero.quienSigue.anterior = primero.anterior;
                        primero = primero.quienSigue;
                    }
                    else
                        primero = null;
                }
            }
            
        }

        private void eliminar(Base p, string nombre)
        {
            if (p.nombre != nombre)
                eliminar(p.quienSigue, nombre);
            else
            {
                p.quienSigue.anterior = p.anterior;
                p.anterior.quienSigue = p.quienSigue;
            }
                    
        }

        public void eliminarInicio()
        {
            if(primero != null)
            {
                if (primero.quienSigue != primero)
                {
                    primero.quienSigue.anterior = primero.anterior;
                    primero.anterior.quienSigue = primero.quienSigue;
                    primero = primero.quienSigue;
                }
                else
                    primero = null;
            }
            
        }

        public void eliminarUltimo()
        {
            if (primero != null)
            {
                if (primero.anterior != primero)
                {
                    primero.anterior.anterior.quienSigue = primero;
                    primero.anterior = primero.anterior.anterior;
                }
                else
                    primero = null;
            }
            
        }

        public string reporte()
        {
            if (primero != null)
                return reporte(primero);
            else
                return "No hay elementos";

        }

        private string reporte(Base p)
        {
            if (p.quienSigue == primero)
                return p.ToString();
            else
                return p.ToString() + Environment.NewLine + Environment.NewLine + reporte(p.quienSigue);
        }

        public string reporteInverso()
        {
            if (primero != null)
                return reporteInverso(primero.anterior);
            else
                return "No hay elementos";
        }

        private string reporteInverso(Base p)
        {
            if (p.anterior == primero.anterior)
                return p.ToString();
            else
                return p.ToString() + Environment.NewLine + Environment.NewLine + reporteInverso(p.anterior);
        }

        public void insertarDespuesDe(Base p, string nombre)
        {
            Base temp = primero;
            while (temp.nombre!=nombre)
            {
                temp = temp.quienSigue;
            }
            p.quienSigue = temp.quienSigue;
            p.anterior = temp;
            temp.quienSigue = p;
        }

        public string recorrido(string nombre, DateTime horaInicio, DateTime horaFin)
        {
            return "";
        }

        public override string ToString()
        {
            return numeroBases.ToString();
        }
    }
}
