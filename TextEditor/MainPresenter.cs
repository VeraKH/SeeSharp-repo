using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Editor_4_Lb;

namespace Text_Editor_4
{
    class MainPresenter
    {
        private readonly IMainForm p_view;
        private readonly IFileManager p_manager;
        private readonly IMassageService p_service;
        private string CurrentFilePath;


        public MainPresenter(IMainForm view, IFileManager manager, IMassageService service)
        {
            p_view = view;
            p_manager = manager;
            p_service = service;


            p_view.SetSymbolCount(0);
            string content = p_view;
            int count =p_manager.GetSymbolCount(content);

            p_view.ContentChanged += p_view_ContentChanged;
            p_view.FileOpenClick += p_view_FileOpenClick;
            p_view.FileSaveClick += p_view_FileSaveClick;
            

        }


        void p_view_FileSaveClick(object sender, EventArgs e)
        {
             try
            {
                string content = p_view.Content;
                p_manager.SaveContent(content, CurrentFilePath);
                p_service.ShowMessage("File has been saved");
            }

            catch (Exception ex)
            {
                p_service.ShowErrow(ex.Message);
            }
        }

        void p_view_FileOpenClick(object sender, EventArgs e)
        {
             try{
            
            string FilePath = p_view.FilePath;
            bool IsExist = p_manager.isExist(FilePath);
            if(!IsExist)
            {
                p_service.ShowExclamation("The file doesn&t exist");
                return;
            }

            CurrentFilePath = FilePath;

            string content = p_manager.GetContent(FilePath);
            int count = p_manager.GetSymbolCount(content);

            p_view.Content = content;
            p_view.SetSymbolCount(count);
            
            }
           
     
            catch (Exception ex)
            {
            p_service.ShowErrow(ex.Message);
            }
        
        }

        void p_view_ContentChanged(object sender, EventArgs e)
        {
            string content = p_view.Content;
            int count = p_manager.GetSymbolCount(content);
            p_view.SetSymbolCount(count);
        }
    
    }
}
