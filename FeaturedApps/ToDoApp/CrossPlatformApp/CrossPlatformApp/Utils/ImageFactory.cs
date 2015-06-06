namespace CrossPlatformApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    public class ImageFactory : BindableObject
    {
        #region CachedSource Property
        
        public static readonly BindableProperty CachedSourceProperty = BindableProperty.CreateAttached<ImageFactory, string>(
               bindable => ImageFactory.GetCachedSource(bindable),
               null, /* default value */
               BindingMode.OneWay,
               null,
               (b, o, n) => ImageFactory.OnCachedSourceChanged(b, o, n),
               null,
               null);

        public static string GetCachedSource(BindableObject bo)
        {
            return (string)bo.GetValue(ImageFactory.CachedSourceProperty);
        }

        public static void SetCachedSource(BindableObject bo, string value)
        {
            bo.SetValue(ImageFactory.CachedSourceProperty, value);
        }

        public static void OnCachedSourceChanged(BindableObject sender, string oldValue, string newValue)
        {
            //Good location to initialize the attached behaviour
            var instance = sender as Image;
            if (instance == null)
            {
                return;
            }
        }

        #endregion

        #region SharedFactory Property

        public static readonly BindableProperty SharedFactoryProperty = BindableProperty.CreateAttached<ImageFactory, ImagesCache>(
               bindable => ImageFactory.GetSharedFactory(bindable),
               null, /* default value */
               BindingMode.OneWay,
               null,
               (b, o, n) => ImageFactory.OnSharedFactoryChanged(b, o, n),
               null,
               null);

        public static ImagesCache GetSharedFactory(BindableObject bo)
        {
            return (ImagesCache)bo.GetValue(ImageFactory.SharedFactoryProperty);
        }

        public static void SetSharedFactory(BindableObject bo, ImagesCache value)
        {
            bo.SetValue(ImageFactory.SharedFactoryProperty, value);
        }

        public static void OnSharedFactoryChanged(BindableObject sender, ImagesCache oldValue, ImagesCache newValue)
        {
            //Good location to initialize the attached behaviour
            var instance = sender as Image;
            if (instance == null)
            {
                return;
            }

            LoadImageSourceAsync(instance, newValue);
        }

        private static void LoadImageSourceAsync(Image instance, ImagesCache images)
        {
            var factory = images;
            if (factory != null)
            {
                instance.Source = factory.FromCachedResource(GetCachedSource(instance));
            }
        }

        #endregion
    }

    public class ImagesCache
    {
        private Dictionary<string, WeakReference<ImageSource>> Cache;

        public ImagesCache ()
	    {
            Cache = new Dictionary<string, WeakReference<ImageSource>>();
	    }

        public ImageSource FromCachedResource(string resource)
        {
            if (Cache.ContainsKey(resource))
            {
                ImageSource result;
                Cache[resource].TryGetTarget(out result);

                return result;
            }
            {
                /*var imgArrayLazyTask = new Lazy<Task<byte[]>>(
                    async () =>
                    {
                        var assembly = typeof(ImageFactory).GetTypeInfo().Assembly;

                        using (var inputStream = assembly.GetManifestResourceStream(resource))
                        using (var outputStream = new MemoryStream())
                        {
                            await inputStream.CopyToAsync(outputStream);
                            return outputStream.ToArray();
                        }
                    },
                    isThreadSafe: true);
                    
                imageSource = new StreamImageSource() { Stream = async _ => new MemoryStream(await imgArrayLazyTask.Value) };
                 */
                //imageSource = new StreamImageSource { Stream = (c) => GetStreamedImage(resource)};
                var source = FileImageSource.FromFile(resource);
                Cache[resource] = new WeakReference<ImageSource>(source);

                return source;
            }
        }

        private Task<Stream> GetStreamedImage(string resource)
        {
            return Task.Factory.StartNew(() =>
            {
                return Stream.Null;
            });
        }
    }
}