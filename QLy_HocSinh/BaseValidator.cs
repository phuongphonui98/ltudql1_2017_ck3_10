using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLy_HocSinh
{
    public abstract partial class BaseValidator : Component
    {

        ErrorProvider errorProvider = new ErrorProvider();
        public string ErrorMessage { get; set; }
        public Icon ErrorIcon { get => errorProvider.Icon; set => errorProvider.Icon = value; }
        Control control2Validate;
        [TypeConverter(typeof(ReferenceConverter))]
        public Control ControlToValidate
        {
            get => control2Validate;
            set
            {
                if (control2Validate != null && !DesignMode)
                {
                    control2Validate.Validating -= Control2Validate_Validating;
                }
                control2Validate = value;
                if (control2Validate != null && !DesignMode)
                {
                    control2Validate.Validating += Control2Validate_Validating;
                }

            }
        }
        public void Control2Validate_Validating(object sender, CancelEventArgs e)
        {
            if (!Validate())
            {
                errorProvider.SetError(control2Validate, ErrorMessage);
            }
            else
            {
                errorProvider.SetError(control2Validate, "");
            }
        }
        public abstract bool Validate();
      
    }
}
