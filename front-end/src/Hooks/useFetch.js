import { useEffect, useState } from "react";

function useFetch(id) {
  const [songState, setSongState] = useState(1);
  const [quoteState, setQuoteState] = useState({});
  const [picState, setPicState] = useState(1);

  const BACKEND_URL_Songs = "http://localhost:5000/songs";
  const BACKEND_URL_Quotes = "http://localhost:5000/quotes";
  const BACKEND_URL_Pics = "http://localhost:5000/pics";

  let songCode = id;

  if (songCode <= 1) {
    songCode = 1 + Math.round(Math.random() * 4);
  }

  const PATH = songCode;

  async function fetchData() {
    let result = await fetch(`${BACKEND_URL_Songs}/${PATH}`);
    let data = await result.json();
    setSongState(data);

    let QuoteResult = await fetch(`${BACKEND_URL_Quotes}/${PATH}`);
    let QuoteData = await QuoteResult.json();
    setQuoteState(QuoteData);

    let PicResult = await fetch(`${BACKEND_URL_Pics}/${PATH}`);
    let PicData = await PicResult.json();
    setPicState(PicData);
  }

  useEffect(() => {
    fetchData();
  }, [id]);

  let DATA = {
    songData: songState,
    quoteData: quoteState,
    picData: picState,
  };
  console.log(DATA);
  return DATA;
}

export default useFetch;
