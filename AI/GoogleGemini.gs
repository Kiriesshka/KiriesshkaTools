//Этот скрипт нужно расположить в Google Apps Script и скопировать ссылку на него(ее даст сервис после деплоя как web приложения)

function doPost(e) {
  var parameter = e.parameter.parameter;

  const apiKey = "";

  const url = 'https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash:generateContent?key='+apiKey;
  
  const safetySettings = [
    {
      category: "HARM_CATEGORY_HARASSMENT",
      threshold: "BLOCK_NONE",
    },
    {
      category: "HARM_CATEGORY_HATE_SPEECH",
      threshold: "BLOCK_NONE",
    },
    {
      category: "HARM_CATEGORY_SEXUALLY_EXPLICIT",
      threshold: "BLOCK_NONE",
    },
    {
      category: "HARM_CATEGORY_DANGEROUS_CONTENT",
      threshold: "BLOCK_NONE",
    }
  ];
  
  const payload = {
    contents: [{ parts: [{ text: parameter }] }],
    safetySettings: safetySettings,  // Добавлено настройки безопасности
  };

  const res = UrlFetchApp.fetch(url,{
    payload: JSON.stringify(payload),
    contentType: "application/json",
  });
  const obj = JSON.parse(res.getContentText());

  var responseMessage;
  if(
    obj.candidates &&
    obj.candidates.length > 0 &&
    obj.candidates[0].content.parts.length > 0
  ){
    
      responseMessage=obj.candidates[0].content.parts[0].text;
    
  }else{
    responseMessage = "Error type 0";
  }

  return ContentService.createTextOutput(responseMessage).setMimeType(ContentService.MimeType.TEXT);
}
