# form-serializer
Used for serializing form data on 'submit' event

## Usage
```javascript
    ;(function() {
        $('#target-form').formSerializer(function(data, e) {
            console.log(data); // serialize data
            console.log(e); // event data
        });
    })();
```

