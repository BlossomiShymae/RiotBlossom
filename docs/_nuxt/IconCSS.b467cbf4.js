import{a as d,at as m,C as x,I as o,o as S,i as f,au as I,u as a,x as z}from"./entry.018413b1.js";const y=d({__name:"IconCSS",props:{name:{type:String,required:!0},size:{type:String,default:""}},setup(_){var r;const s=_;m(n=>({faa288c6:a(p)}));const e=x();(r=e==null?void 0:e.nuxtIcon)!=null&&r.aliases;const l=o(()=>{var n;return(((n=e==null?void 0:e.nuxtIcon)==null?void 0:n.aliases)||{})[s.name]||s.name}),p=o(()=>`url('https://api.iconify.design/${l.value.replace(":","/")}.svg')`),c=o(()=>{var t,i,u;if(!s.size&&typeof((t=e.nuxtIcon)==null?void 0:t.size)=="boolean"&&!((i=e.nuxtIcon)!=null&&i.size))return;const n=s.size||((u=e.nuxtIcon)==null?void 0:u.size)||"1em";return String(Number(n))===n?`${n}px`:n});return(n,t)=>(S(),f("span",{style:I({width:a(c),height:a(c)})},null,4))}});const g=z(y,[["__scopeId","data-v-5217de21"]]);export{g as default};
