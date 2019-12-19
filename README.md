# Google reCaptcha v3, C# Development

As you may know, Google reCaptcha V3 in a new version of reCaptcha which doesn't bother user to pass the "I'm not robot" check and quizes!

It is an invisible captcha and based on user interactions and other data such as IP, requests, website traffic and some other data to check if the user is a real human or a robot. It returns false if there is a repetitive request and returns true with a score between 0 and 1. If the requests comes from a robot, the score will be close to zero. Using this code, you can implement reCaptcha v3 using C#.

Put this code to head HTML
```
<script src="https://www.google.com/recaptcha/api.js?render=your_site_key"></script>
```

Then put this code to your form
```
<script>
    grecaptcha.ready(function () {
        grecaptcha.execute('your_site_key', { action: 'your_action_name' })
            .then(function (token) {
                document.getElementById('g-recaptcha-response').value = token;
            });
    });
</script>
```

And, add this element to your <form>
```
<input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response">
```
  
Well done, nothing is needed more but in your backend.

In visual studio pacage manager install Newtornsoft.Json

```
PM> Install-Package Newtonsoft.Json
```

Use reCaptcha.cs class to check the response and score of the request.
