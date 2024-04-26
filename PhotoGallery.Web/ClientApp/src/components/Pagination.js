import React from 'react';

function Pagination({ currentPage, totalPageCount, onPageChange }) {
    return (
        <div className="pagination">
            <button onClick={() => onPageChange('prev')} disabled={currentPage === 1}>Prev</button>
            <span>Page {currentPage} of {totalPageCount}</span>
            <button onClick={() => onPageChange('next')} disabled={currentPage === totalPageCount}>Next</button>
        </div>
    );
}

export default Pagination;