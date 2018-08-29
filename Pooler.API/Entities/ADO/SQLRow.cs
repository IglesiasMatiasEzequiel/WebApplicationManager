using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Pooler.API.Entities.ADO
{
    public class SQLRow
    {
        public IList<SQLColumn> Columns { get; set; }

        #region Get Methods

        public string GetValue(string name)
        {
            SQLColumn field = Columns.FirstOrDefault(it => string.Equals(it.Name, name, StringComparison.CurrentCultureIgnoreCase));

            if (field == null)
                throw new NoNullAllowedException("SUBx201704291439 - The field " + name.ToUpper() + " not exists");

            return field.Value;
        }

        public int? GetValueIntNull( string name)
        {
            string value = GetValue( name);

            if (string.IsNullOrEmpty(value)) return null;

            return Convert.ToInt32(value);
        }

        public int GetValueInt(string name)
        {
            int? value = GetValueIntNull( name);

            if (value == null)
                throw new NoNullAllowedException("SUBx201704291438 - The value of the '" + name.ToUpper() + "' can not be NULL");

            return Convert.ToInt32(value);
        }

        public long? GetValueLongNull(string name)
        {
            string value = GetValue( name);

            if (string.IsNullOrEmpty(value)) return null;

            return Convert.ToInt64(value);
        }

        public long GetValueLong(string name)
        {
            long? value = GetValueLongNull(name);

            if (value == null)
                throw new NoNullAllowedException("SUBx201704291438 - The value of the '" + name.ToUpper() + "' can not be NULL");

            return Convert.ToInt64(value);
        }

        public double? GetValueDoubleNull(string name)
        {
            string value = GetValue(name);

            if (string.IsNullOrEmpty(value)) return null;

            return Convert.ToDouble(value);
        }

        public double GetValueDouble(string name)
        {
            double? value = GetValueDoubleNull(name);

            if (value == null)
                throw new NoNullAllowedException("SUBx201704291437 - The value of the '" + name.ToUpper() + "' can not be NULL");

            return Convert.ToDouble(value);
        }

        public bool GetValueBool(string name)
        {
            return IsBoolean(GetValue(name));
        }

        public DateTime? GetValueDateTimeNull(string name)
        {
            string value = GetValue(name);

            if (string.IsNullOrEmpty(value)) return null;

            return Convert.ToDateTime(value);
        }

        public DateTime GetValueDateTime(string name)
        {
            DateTime? value = GetValueDateTimeNull(name);

            if (value == null)
                throw new NoNullAllowedException("SUBx201704291437 - The value of the '" + name.ToUpper() + "' can not be NULL");

            return Convert.ToDateTime(value);
        }

        private static bool IsBoolean(string value)
        {
            if (value == null) return false;
            return value == "1" || value.ToUpper() == "TRUE" || value.ToUpper() == "S" || value.ToUpper() == "SI" || value.ToUpper() == "YES";
        }

        #endregion
    }
}