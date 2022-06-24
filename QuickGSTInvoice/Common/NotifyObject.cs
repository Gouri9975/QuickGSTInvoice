using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Common.Common
{

    [SerializableAttribute]
    public class MyObservableCollection<T> : ObservableCollection<T>
    {
        public DateTime SyncDate { get; set; }
        public string SyncComapnyAPI { get; set; }

        public void SetItem(
                                      int index,
                                      T item
                                  )
        {
            base.SetItem(index, item);
        }

        public MyObservableCollection<T> Clone()
        {
            MyObservableCollection<T> newo = new Common.MyObservableCollection<T>();
            newo.SyncComapnyAPI = this.SyncComapnyAPI;
            newo.SyncDate = this.SyncDate;

            foreach (T t in this)
            {
                newo.Add(t);
            }
            return newo;
        }
        public static MyObservableCollection<T> ConvertFromList(List<T> List)
        {
            MyObservableCollection<T> newo = new Common.MyObservableCollection<T>();
            foreach (T t in List)
            {
                newo.Add(t);
            }
            return newo;
        }

        public MyObservableCollection<T> GetPage( int page, int pageSize)
        {
            return  MyObservableCollection<T>.ConvertFromList(this.Skip(page * pageSize).Take(pageSize).ToList()) ;
        }
    }
    [DataContract]
    public abstract class NotifyObject : INotifyPropertyChanged
    {
        #region Fields
        [IgnoreDataMember]
        private Dictionary<string, object> _values = new Dictionary<string, object>();

        [IgnoreDataMember]
        private Dictionary<string, object> Values
        {
            get
            {
                if (_values == null)
                {
                    _values = new Dictionary<string, object>();
                }

                return _values;
            }
        }

        #endregion

        protected void SetValue<T>(Expression<Func<T>> propertySelector, T value)
        {
            string propertyName = GetPropertyName(propertySelector);

            Values[propertyName] = value;
            NotifyPropertyChanged(propertySelector);
        }

        protected T GetValue<T>(Expression<Func<T>> propertySelector)
        {
            string propertyName = GetPropertyName(propertySelector);

            return GetValue<T>(propertyName);
        }

        protected T GetValue<T>(string propertyName)
        {
            object value;
            if (Values.TryGetValue(propertyName, out value))
            {
                return (T)value;
            }

            return default(T);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        protected string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new InvalidOperationException();
            }

            return memberExpression.Member.Name;
        }

        protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertySelector)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                string propertyName = GetPropertyName(propertySelector);

                /* This part write the to the UI element */
                Task.Run(() =>
                {
                    try
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                    }
                    catch (Exception)
                    {
                    }
                }
                );
            }
        }
    }
}