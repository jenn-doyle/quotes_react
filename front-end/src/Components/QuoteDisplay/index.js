import "./QuoteDisplay.css";

function QuoteDisplay({ data }) {
  // take in data from fetch
  return (
    <div className="quote-display">
      <p className="quote">"{data.quote}"</p>
      <h4 className="said-by">
        <span>~ </span>
        {data.saidBy}
      </h4>
      <p className="suggested-by">
        Suggested by: <span>{data.suggestedBy}</span>
      </p>
    </div>
  );
}

export default QuoteDisplay;
