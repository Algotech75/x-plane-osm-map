mkdir ..\..\release-exe\
copy ..\assets\*.html ..\..\release-exe\
copy ..\assets\*.css  ..\..\release-exe\
copy ..\assets\*.js   ..\..\release-exe\
copy ..\assets\*.png  ..\..\release-exe\
copy   Release\*.exe  ..\..\release-exe\
cd ..\..\
del release-exe.zip
"C:\Program Files\7-Zip\7z.exe" a -mmt4 -tzip release-exe.zip release-exe\
