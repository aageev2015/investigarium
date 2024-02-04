let config = {
  "type" : "doc",
  "children" : [ {
    "type" : "h1",
    "children" : [ "Just a header" ]
  }, {
    "type" : "p",
    "children" : [ "Some text in there" ]
  }, {
    "type" : "ul",
    "children" : [ {
      "type" : "li",
      "children" : [ {
        "type" : "p",
        "children" : [ "Item 1. ", {
          "type" : "b",
          "children" : [ "bold" ]
        } ]
      } ]
    }, {
      "type" : "li",
      "children" : [ {
        "type" : "p",
        "children" : [ "Item 2" ]
      } ]
    } ]
  } ]
}


let build = (config) => {
	let isNullOrEmptyString = (s) => (typeof s !== "string") || s === null || s === "";
	if (typeof config === "string") return document.createTextNode(config);
	if (typeof config !== "object") return undefined;
	let chld = config.children;
	if (isNullOrEmptyString(config.type) || !Array.isArray(chld))  return undefined;
	let result_node = document.createElement(config.type);
	config.children.map(n => result_node.append(build(n)));
	return result_node;
}

let d = document, 
	build2 = (r) => 
			(typeof r === "string") 
		?	d.createTextNode(r) 
		:	r.children.reduce(
				(n, c) => {
					n.append(build2(c));
					return n;
				}
			,	d.createElement(r.type));

let node = build(config);


let build2 = (r) => 
			(typeof r === "string") 
		?	r 
		:		`<${r.type}>`
			+	r.children.reduce((n, c) => n + build2(c), "")
			+	`</${r.type}>`
let node = build2(config);




let one_o = "  ";
let build3 = (r, o) => 
			(typeof r === "string") 
		?	`${o}${r}\n`
		:		`${o}<${r.type}>\n`
			+	r.children.reduce((n, c) => 
					n + build3(c, o + one_o), 
					"")
			+	`${o}</${r.type}>\n`
			
let node = build3(config, "");


