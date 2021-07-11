import { useEffect } from "react";

function usePost(newQuote) {
  function makePost() {
    // our form returns object
    // give object to post to add to db
    const requestOptions = {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(newQuote),
    };
    fetch("http://localhost:5000/quotes", requestOptions);
  }

  useEffect(() => {
    makePost(newQuote);
  }, [newQuote]);
}

export default usePost;
