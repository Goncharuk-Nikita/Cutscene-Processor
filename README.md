# Cutscene-Processor

В примере определено 2 решения
1. Основан на составлении Unity events в качестве действий. 
2. Создании действий, затем сериализацию последовательности действий в XML формат, и его десириализацию при проигрывании Cutscene. 


Второе решение (основное):
Cutscene содержит:
   1.  Список диалоговых сообщений;
   2.  Фокус камеры;

Для создания Cutscene вам необходимо прикрепить CutsceneCreator скрипт к любому GameObject. Затем, после 
создания cutscene сериализовать его в XML, нажав кнопку "Save to XML". 
Для проигрывания данной Cutscene вам необходимо прикрепить CutsceneXmlPlayer и передать в него TextAsset сериализованной Cutscene.

![Alt Text](https://github.com/Goncharuk-Nikita/Cutscene-Processor/blob/master/2018-12-31_17-13-30.gif)
