import { useState } from "react";
import useFetch from "../../Hooks/useFetch";
import AddQuote from "../AddQuote";
import QuoteDisplay from "../QuoteDisplay";
import ReactPlayer from "react-player";
import "./App.css";
import Button from "../Button";

function App() {
  const [dataState, setDataState] = useState(0);
  // fetch songs here using our custom hook - useFetch
  const appData = useFetch(dataState);

  function refreshPage() {
    window.location.reload();
  }

  return (
    <div className="App">
      <header className="App-header">
        <h2 className="quote-title">Your Inspirational Quote</h2>
        <Button handleChange={refreshPage} text={"Click for more"} />
        <QuoteDisplay data={appData.quoteData} />
        <AddQuote />
        <br />
      </header>
      {/* <h3 className="sub-heading"> Alternative inspiration below... 😁 </h3> */}
      <div className="mid-sect">
        <ReactPlayer
          className="glass-box"
          url={appData.songData.link}
          width="300px"
          height="250px"
        />
        <img
          className="glass-box"
          src={appData.picData.picLink}
          alt="cute-animals"
        />
      </div>
      <Button
        handleChange={refreshPage}
        text={"Alternative inspiration... ⬆😁"}
      />
      <br />
      {/* <footer>
        <h3>Have an inspiring day 😁</h3>
      </footer> */}
    </div>
  );
}

export default App;
