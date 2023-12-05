async function fetchData() {
    return await fetch(`https://...`);
  }
const getData = cache(fetchData);

async function MyComponent() {
    getData();
    // ... some computational work  
    await getData();
    // ...
  }