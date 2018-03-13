function newGuid() {
    function f() {
        return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
  	}
  	return f() + f() + '-' + f() + '-' + f() + '-' + f() + '-' + f() + f() + f();
}
