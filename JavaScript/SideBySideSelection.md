## Side by Side Selection

##### Dependencies 
(None)

Script
``` javascript
var ns = ns || {};
    
ns.bootstrapCustomMultiSelectOptions1 = function(selector) {
  var cmos = document.querySelectorAll(selector);
  for (i = 0; i < cmos.length; i++) {
    var cmo = cmos[i];
    var src = cmo.querySelector('[cmo1-type=src]');
    var dest = cmo.querySelector('[cmo1-type=dest]');

    function addRemoveColumn(add) {
      var from = (add ? src : dest);
      var to = (add ? dest : src);
      var selectedValues = from.querySelectorAll('option');

      for (i = 0; i < selectedValues.length; i++) {
        if (selectedValues[i].selected) {
          var elem = from.querySelector('option[value="' + selectedValues[i].value + '"]');
          if (elem) {
            to.innerHTML += elem.outerHTML;
            from.removeChild(elem);
          }
        }
      }
    }

    function upDownClicked(up) {
      var selectedValues = (up ? dest.querySelectorAll('option')  : [].slice.call(dest.querySelectorAll('option'), 0).reverse());

      for (i = 0; i < selectedValues.length; i++) {
        if (selectedValues[i].selected) {
          var elem = dest.querySelector('option[value="' + selectedValues[i].value + '"]');
          var val = elem.getAttribute('value');
          var txt = elem.text;
          var target = (up ? elem.previousElementSibling : elem.nextElementSibling);

          if (target) {
            elem.setAttribute('value', target.value);
            elem.text = target.text;
            elem.selected = false;
            target.setAttribute('value', val);
            target.text = txt;
            target.selected = true;
          }
          else {
            break;
          }
        }
      }
    }

    cmo.querySelector('[cmo1-type=add]').addEventListener('click', () => addRemoveColumn(true));
    cmo.querySelector('[cmo1-type=remove]').addEventListener('click', () => addRemoveColumn(false));
    cmo.querySelector('[cmo1-type=up]').addEventListener('click', () => upDownClicked(true));
    cmo.querySelector('[cmo1-type=down]').addEventListener('click', () => upDownClicked(false));
  }
};
```
Usage
``` html
<!DOCTYPE html>
<html>
<head>
  <title>Page Title</title>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
</head>
<body>
  <div class="row" id="customizeGridColumns">
    <div class="col-3">
        <div>Available Columns</div>
        <select multiple cmo1-type="src" size="10" style="width:150px;height:12em;">
          <option value="1">One</option>
          <option value="2">Two</option>
          <option value="3">Three</option>
          <option value="4">Four</option>
          <option value="5">Five</option>
          <option value="6">Six</option>
          <option value="7">Seven</option>
          <option value="8">Eight</option>
          <option value="9">Nine</option>
        </select>
      </div>
    <div class="col-3">
      <button type="button" cmo1-type="add">Add</button>
      <button type="button" cmo1-type="remove">Remove</button>
    </div>
    <div class="col-3">
      <div>Selected Columns</div>
      <select multiple cmo1-type="dest" style="width:150px;height:12em;">
      </select>
    </div>
    <div class="col-3">
      <button type="button" cmo1-type="up">Up</button>
      <button type="button" cmo1-type="down">Down</button>
    </div>
  </div>
  <script>
     ns.bootstrapCustomMultiSelectOptions1('#customizeGridColumns');
  </script>
</body>
</html>
```

