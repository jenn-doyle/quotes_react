import { useState } from "react";
import usePost from "../../Hooks/usePost";
import "./AddQuote.css";

function AddQuoteInput() {
  const [data, setData] = useState("");
  const [postData, setPostData] = useState("");

  function UpdateData(event) {
    const key = event.target.id;
    const newValue = event.target.value;
    setData({ ...data, [key]: newValue });
  }
  // post quotes from here using usePost custom hook
  usePost(postData);

  return (
    <form id="form" className="add-quote-form" action="submit">
      <input
        type="text"
        placeholder="Quote"
        id="Quote"
        onChange={(e) => UpdateData(e)}
      />
      <input
        type="text"
        placeholder="Said By"
        id="SaidBy"
        onChange={(e) => UpdateData(e)}
      />
      <input
        className="name"
        type="text"
        placeholder="Your Name"
        id="SuggestedBy"
        onChange={(e) => UpdateData(e)}
      />
      <button
        className="add-quote-btn"
        onClick={(event) => {
          event.preventDefault();
          setPostData(data);
          document.querySelector(".add-quote-form").reset();
        }}
      >
        Add Quote
      </button>
    </form>
  );
}

export default AddQuoteInput;
