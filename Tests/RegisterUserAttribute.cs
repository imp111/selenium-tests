using AutoFixture;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class RegisterUserAttribute : AutoDataAttribute
    {
        public RegisterUserAttribute() : 
            base ( 
                    () => 
                    { 
                        var fixture = new Fixture();
                        fixture.Customize<RegisterUserModel>(x => x.With(x => x.Email, "testemail@abv.bg")
                        .With(x => x.Password, "testPassword@123"));

                        return fixture;
                    }
                 )    
        {
            
        }
    }
}
