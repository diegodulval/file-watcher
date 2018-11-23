using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace FileWatcher
{
    class Program
    {
        static void Main(string[] args)
        {           
            int opcao; 
            do 
            { 
                Console.WriteLine("[ 1 ] Monitorar arquivo"); 
                Console.WriteLine("[ 0 ] Sair do Software"); 
                Console.WriteLine("-------------------------------------"); 
                Console.Write("Digite uma opção: "); 
                opcao = Int32.Parse(Console.ReadLine()); 
                switch (opcao) 
                { 
                    case 1: 
                        FileWatcher();
                        break;
                    case 0: 
                        saiPrograma(); 
                        break;                        
                    default: 
                         Console.Write("Opção inválida!"); 
                        break; 
                } 
                Console.ReadKey(); 
                Console.Clear(); 
            } 
            while (opcao != 0);              
        }       
        
        private static void FileWatcher(){
            Console.Clear(); 
            Console.WriteLine("----------------------------------------------------------------"); 
            Console.WriteLine("***************| MONITORANDO ARQUIVO |**************************"); 
            Console.WriteLine("----------------------------------------------------------------"); 

            Console.Write("Caminho do diretório a ser monitorado: "); 
            string folderPath = Console.ReadLine();

            Console.Write("Nome do arquivo a ser monitorado: "); 
            string fileName = Console.ReadLine(); 

            Console.Clear(); 
            Console.WriteLine("----------------------------------------------------------------"); 
            Console.WriteLine("***************| ÚLTIMAS LINHAS INSERIDAS |*********************"); 
            Console.WriteLine("----------------------------------------------------------------"); 

            FileSystemWatcher fsw = new FileSystemWatcher();
            fsw.Path = folderPath;
            fsw.Filter = "*" + fileName + "*";
            fsw.NotifyFilter = NotifyFilters.Size;
            fsw.Changed += new FileSystemEventHandler((o, e) => {Filechanged(folderPath + "\\" + fileName);});
            fsw.EnableRaisingEvents = true;
        }  

        private static void Filechanged(string filePath){
        try
            {
                FileStream fo = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fo);
                string lastLine = File.ReadLines(filePath).Last();
                Console.WriteLine(lastLine);
                sr.Close();
                fo.Close();
            }
            catch (IOException ex)
            {
                //Console.WriteLine(ex);
            }
        }

        private static void saiPrograma() 
        { 
            Console.WriteLine(); 
            Console.WriteLine("Pressione qualquer tecla para sair..."); 
        } 
    }    
}
