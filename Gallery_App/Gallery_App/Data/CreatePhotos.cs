using System;
using Gallery_App.Data.Tables;
using System.Collections.Generic;
using System.Text;

namespace Gallery_App.Data
{
    public class CreatePhotos
    {
        public CreatePhotos()
        {
            Create();
        }


        public async void Create()
        {
            Photo picture_1 = new Photo() { Id = new Guid("35b2a8e8-cfd3-4192-90e6-61d08911ee85"), Name = "Природа_1", Image = "p1.png", Date = "2024-03-13" };
            Photo picture_2 = new Photo() { Id = new Guid("d09b2d9d-1b0f-4675-b7a3-312ead72879f"), Name = "Природа_2", Image = "p2.png", Date = "2024-03-13" };
            Photo picture_3 = new Photo() { Id = new Guid("d63f2eca-b4f4-4dc4-a0ab-f706f8091e7d"), Name = "Природа_3", Image = "p3.png", Date = "2024-03-13" };
            Photo picture_4 = new Photo() { Id = new Guid("574630f6-f2cd-4314-b927-caef69fcb6f3"), Name = "Природа_4", Image = "p4.png", Date = "2024-03-13" };
            Photo picture_5 = new Photo() { Id = new Guid("7ed35ec3-378b-4dfd-ab5c-402e519456fb"), Name = "Природа_5", Image = "p5.png", Date = "2024-03-13" };
        }
    }
}
