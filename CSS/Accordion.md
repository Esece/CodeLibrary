## Accordion without JavaScript

Pure CSS Solutionfor Toggling Visibility
``` css
#toggle {
  display:none;
}

#header { 
  display:block;
  padding:10px;
  border:1px solid #aaa;
  background:#aaa;
  cursor: pointer;
}

#detail {
  padding:10px;
  border:1px solid #aaa;
}

#toggle:checked ~ #detail {
   display: none;
}
```

Sample HTML
``` html
<label for="toggle" id="header">HEADER</label>
<input type="checkbox" id="toggle">
<div id="detail">DETAIL</div>
```
