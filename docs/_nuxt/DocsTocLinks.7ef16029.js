import{r as i,P as f,O as h,a1 as g,a as y,e as k,o as u,i as v,F as x,a5 as b,j as p,k as B,t as C,u as H,a6 as S,c as A,l as T,x as q}from"./entry.018413b1.js";const D=()=>{const c=i(),t=i([]),a=i([]),l=e=>e.forEach(o=>{const s=o.target.id;o.isIntersecting?t.value.push(s):t.value=t.value.filter(r=>r!==s)}),d=e=>e.forEach(o=>{c.value.observe(o)});return f(t,(e,o)=>{e.length===0?a.value=o:a.value=e},{deep:!0}),h(()=>c.value=new IntersectionObserver(l)),g(()=>{var e;return(e=c.value)==null?void 0:e.disconnect()}),{visibleHeadings:t,activeHeadings:a,updateHeadings:d}},L={class:"docs-toc-links"},M=["href","onClick"],$=y({__name:"DocsTocLinks",props:{links:{type:Array,default:()=>[]}},emits:["move"],setup(c,{emit:t}){const a=k(),{activeHeadings:l,updateHeadings:d}=D();setTimeout(()=>{d([...document.querySelectorAll(".document-driven-page h1, .docus-content h1"),...document.querySelectorAll(".document-driven-page h2, .docus-content h2"),...document.querySelectorAll(".document-driven-page h3, .docus-content h3"),...document.querySelectorAll(".document-driven-page h4, .docus-content h4")])},300);function e(s){a.push(`#${s}`),t("move",s)}function o(s){t("move",s)}return(s,r)=>{const m=w;return u(),v("ul",L,[(u(!0),v(x,null,b(c.links,n=>(u(),v("li",{key:n.text,class:p([`depth-${n.depth}`])},[B("a",{href:`#${n.id}`,class:p([H(l).includes(n.id)&&"active"]),onClick:S(_=>e(n.id),["prevent"])},C(n.text),11,M),n.children?(u(),A(m,{key:0,links:n.children,onMove:r[0]||(r[0]=_=>o(_))},null,8,["links"])):T("",!0)],2))),128))])}}});const w=q($,[["__scopeId","data-v-a97df893"]]);export{w as default};
